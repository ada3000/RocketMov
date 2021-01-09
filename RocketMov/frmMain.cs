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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketMov
{
    public partial class frmMain : Form
    {
        private List<FileDesc> _files = new List<FileDesc>();
        int fileId = 1;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //lvFiles.Items.Add(new ListViewItem(new[] { "0", "1", "2", "3" }));
            //AddFile(@"F:\Pictures\Tmp\New\2019\(09) LenaPhone\Video\2019-09-02 11-44-03.MOV");
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(1);
            //lvFiles.SelectedItems[0];
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

            var viewDesc = GetViewDesc(file);

            AddOrUpdateFileDesc(viewDesc);
        }

        private void AddOrUpdateFileDesc(FileViewDesc viewDesc)
        {
            if (InvokeRequired)
            {
                Action<FileViewDesc> d = new Action<FileViewDesc>(AddOrUpdateFileDesc);
                Invoke(d, viewDesc);
                return;
            }

            for (int i = 0; i < lvFiles.Items.Count; i++)
            {
                var lvi = lvFiles.Items[i] as ListViewItem;
                if (lvi.Text == viewDesc.Id)
                {
                    lvFiles.Items[i] = viewDesc.ToListViewItem();
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
            cbConvert.Enabled = false;
            var files = _files.ToArray();

            foreach (var file in files)
            {
                if (file.Status == FileStatus.Wait)
                {
                    ConvertFile(file);
                }
            }

            cbConvert.Enabled = true;
        }




        private void ConvertFile(FileDesc file)
        {
            file.Status = FileStatus.Converting;
            AddOrUpdateFileDesc(GetViewDesc(file));

            //ConverterV1(file);
            ConverterV2(file);

            file.Status = FileStatus.Converted;
            AddOrUpdateFileDesc(GetViewDesc(file));
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

            FFMpegArguments
                .FromFileInput(file.PathIn)
                .OutputToFile(file.PathOut, true, options => options
                    .WithVideoCodec(VideoCodec.LibX264)
                    .WithConstantRateFactor(21)
                    .WithAudioCodec(AudioCodec.Aac)
                    .WithVariableBitrate(4)
                    .WithFastStart()
                    .Scale(720, 1280)
                    .UsingThreads(4))
                .ProcessSynchronously();
        }

        private void Engine_ConversionCompleteEvent(object sender, ConversionCompleteEventArgs e)
        {
            //pbConvert.Value = 100;
        }

        private void Engine_ConvertProgressEvent(object sender, ConvertProgressEventArgs e)
        {
            //pbConvert.Value - e.
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
    }

    public enum FileStatus
    {
        Wait,
        Fail,
        Converting,
        Converted
    }
}
