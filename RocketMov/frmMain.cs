using FFMpegCore;
using FFMpegCore.Enums;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketMov
{
    public partial class frmMain : Form
    {
        private List<FileDesc> _files = new List<FileDesc>();
        int fileId = 1;

        private ConvertOptions _convertOptions = new ConvertOptions();
        private bool _stateConverting = false;
        private double _stateProgress = 0;
        private FileDesc _stateSelectedFile;

        private Action _cancelConvertion;
        private Thread _converter;

        public frmMain()
        {
            InitializeComponent();
        }

        public void ReadOptions()
        {
            try
            {
                _convertOptions.Width = int.Parse(cbVideoSize.Text.Split('x')[0]);
                _convertOptions.Height = int.Parse(cbVideoSize.Text.Split('x')[1]);
                _convertOptions.Bitrate = int.Parse(cbVideoBitrate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid arguments");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadOptions();
            //lvFiles.Items.Add(new ListViewItem(new[] { "0", "1", "2", "3" }));
            //AddFile(@"F:\Pictures\Tmp\New\2019\(09) LenaPhone\Video\2019-09-02 11-44-03.MOV");
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedIndices.Count > 0)
            {
                var item = lvFiles.Items[lvFiles.SelectedIndices[0]];
                int fileId = int.Parse(item.SubItems[0].Text);
                _stateSelectedFile = _files.First(f => f.Id == fileId);
            }
            else
            {
                _stateSelectedFile = null;
            }

            UpateUI();
        }

        private void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                AddFile(file);
            }
        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void AddFile(string path)
        {
            var file = new FileDesc
            {
                Id = fileId++,
                PathIn = path,
                PathOut = GetPathOut(path),
                Name = System.IO.Path.GetFileName(path),
                Size = new FileInfo(path).Length,
                Status = FileStatus.Wait
            };

            _files.Add(file);

            UpateUI();
        }

        private void UpateUI()
        {
            if (InvokeRequired)
            {
                Action d = new Action(UpateUI);
                Invoke(d);
                return;
            }

            var files = _files.ToArray();

            for (int j = 0; j < files.Length; j++)
            {
                var viewDes = GetViewDesc(files[j]);
                AddOrUpdateFileDesc(viewDes);
            }

            cbConvert.Enabled = !_stateConverting;
            cbStop.Enabled = _stateConverting;

            pbCurrent.Value = (int)_stateProgress;
            pbCurrent.Visible = _stateConverting;

            txtFileError.Text = _stateSelectedFile?.Error;
        }

        private void AddOrUpdateFileDesc(FileViewDesc viewDesc)
        {
            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                var lvi = lvFiles.Items[i] as ListViewItem;
                if (lvi.Text == viewDesc.Id)
                {
                    var newItem = viewDesc.ToListViewItem();

                    bool isChanged = false;
                    for (int j = 0; j < newItem.SubItems.Count; j++)
                    {
                        if (newItem.SubItems[j].Text != lvi.SubItems[j].Text)
                        {
                            isChanged = true;
                            break;
                        }
                    }

                    if (isChanged)
                    {
                        lvFiles.Items[i] = viewDesc.ToListViewItem();
                    }

                    return;
                }
            }

            lvFiles.Items.Add(viewDesc.ToListViewItem());
        }

        private FileViewDesc GetViewDesc(FileDesc file)
        {
            return new FileViewDesc
            {
                Id = file.Id.ToString(),
                Name = file.Name,
                Size = file.Size / 1024 + " KB",
                Status = file.Status.ToString()
            };
        }

        private string GetPathOut(string path)
        {
            int dotIdx = path.LastIndexOf('.');
            path = path.Substring(0, dotIdx) + "_c.mp4";

            return path;
        }

        private void cbConvert_Click(object sender, EventArgs e)
        {
            _converter?.Abort();

            _converter = new Thread(ConvertFiles);
            _converter.IsBackground = true;
            _converter.Start();
        }

        private void ConvertFiles()
        {
            var files = _files.ToArray();
            _stateConverting = true;
            UpateUI();

            foreach (var file in files)
            {
                if (!_stateConverting)
                {
                    break;
                }

                if (file.Status == FileStatus.Wait)
                {
                    ConvertFile(file);
                }
            }

            _stateConverting = false;
            UpateUI();
        }

        private void ConvertFile(FileDesc file)
        {
            file.Status = FileStatus.Converting;
            _stateProgress = 0;
            UpateUI();

            try
            {
                //ConverterV1(file);
                ConverterV2(file);

                file.Status = FileStatus.Converted;
            }
            catch (FFMpegCore.Exceptions.FFMpegException ex)
            {
                file.Status = FileStatus.Fail;
                file.Error = ex.Message + "\r\n" + ex.FfmpegErrorOutput.Replace("\n","\r\n");
            }
            catch (Exception ex)
            {
                file.Status = FileStatus.Fail;
                file.Error = ex.Message;
            }

            UpateUI();
        }

        private void ConverterV1(FileDesc file)
        {
            var conversionOptions = new ConversionOptions
            {
                //MaxVideoDuration = TimeSpan.FromSeconds(30),
                //VideoAspectRatio = VideoAspectRatio.R16_9,
                CustomHeight = 1280,
                CustomWidth = 720,
                VideoSize = MediaToolkit.Options.VideoSize.Custom,
                VideoBitRate = 4 * 1024
            };

            using (var engine = new Engine(@"F:\Pictures\Tmp\Converter\ffmpeg.exe"))
            {
                engine.CustomCommand("-threads 4");
                engine.ConvertProgressEvent += Engine_ConvertProgressEvent;
                engine.ConversionCompleteEvent += Engine_ConversionCompleteEvent;
                //engine.f
                engine.Convert(new MediaFile(file.PathIn), new MediaFile(file.PathOut), conversionOptions);
            }
        }

        private void ConverterV2(FileDesc file)
        {
            FFMpegOptions.Configure(new FFMpegOptions { RootDirectory = @"D:\Git\RocketMov\RocketMov\ffmpeg" });
            var fileInfo = FFProbe.Analyse(file.PathIn);
            FFMpegArguments
                .FromFileInput(file.PathIn)
                .OutputToFile(file.PathOut, true, options => options
                    .WithVideoCodec(VideoCodec.LibX264)
                    .WithConstantRateFactor(21)
                    .WithAudioCodec(AudioCodec.Aac)
                    .WithVideoBitrate(_convertOptions.Bitrate)
                    .WithFastStart()
                    .Scale(_convertOptions.Width, _convertOptions.Height)
                    .UsingThreads(4))
                    .NotifyOnProgress(onConvertProgress, fileInfo.Duration)
                    .CancellableThrough(out _cancelConvertion)
                .ProcessSynchronously();
        }



        private void onConvertProgress(double obj)
        {
            _stateProgress = obj;
            UpateUI();
        }

        private void Engine_ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
        {
            //pbConvert.Value = 100;
        }

        private void Engine_ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
        {
            //pbConvert.Value - e.
        }

        private void cbVideoSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadOptions();
        }

        private void cbVideoBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadOptions();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _cancelConvertion?.Invoke();
            }
            catch (Exception ex) { }

            _stateConverting = false;
        }

        private void cbStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cancelConvertion?.Invoke();
            }
            catch (Exception ex) { }

            _stateConverting = false;
            UpateUI();
        }

        private void cbVideoSize_TextUpdate(object sender, EventArgs e)
        {
            ReadOptions();
        }

        private void cbVideoBitrate_TextUpdate(object sender, EventArgs e)
        {
            ReadOptions();
        }
    }

    public class FileViewDesc
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new[] { Id.ToString(), Name, Size, Status });
        }
    }

    public class FileDesc
    {
        public int Id { get; set; }
        public string PathIn { get; set; }
        public string PathOut { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public FileStatus Status { get; set; }
        public string Error { get; set; }
    }

    public enum FileStatus
    {
        Wait,
        Fail,
        Converting,
        Converted
    }
}
