namespace RetroBatGameListComparator.Models;

public class DownloadProgress
{
    public int Percent { get; set; }

    public long BytesReceived { get; set; }

    public long TotalBytes { get; set; }

    public bool IsCompleted =>
        TotalBytes > 0 &&
        BytesReceived >= TotalBytes;

    public double ReceivedMB =>
        BytesReceived / 1024d / 1024d;

    public double TotalMB =>
        TotalBytes / 1024d / 1024d;
}