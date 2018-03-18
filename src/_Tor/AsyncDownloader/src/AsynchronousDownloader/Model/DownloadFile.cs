using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AsynchronousDownloader.ViewModel;

namespace AsynchronousDownloader.Model
{
    /// <summary>
    /// Fody used for PropertyChanged - all properties will notify
    /// </summary>
    public class DownloadFile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Filename { get; set; }

        public string DownloadLocation { get; set; }

        private string uri;
        public string Uri
        {
            get => uri;
            set
            {
                uri = value;
                Filename = value.Split('/').Last();
                FileSize = CalculateFileSize(value);
            }
        }

        public string DownloadPercentageString { get; set; }

        public int DownloadPercentage { get; set; }

        public string DownloadTime { get; set; }

        public string DownloadSpeed { get; set; }

        public string FileSize { get; set; }

        private DownloadStatus downloadStatus;
        public DownloadStatus DownloadStatus
        {
            get => downloadStatus;
            set
            {
                downloadStatus = value;
                DownloadFileViewModel.CanDownload(this);
            }
        }

        private string CalculateFileSize(string uri)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "HEAD";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return $"{Math.Round((double) resp.ContentLength / 1048576, 2)} MB";
        }
    }

    public enum DownloadStatus
    {
        NotDownloaded,
        Downloading,
        Downloaded
    }
}
