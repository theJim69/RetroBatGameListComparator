using System;

namespace RetroBatGameListComparator.Helpers;

public static class Constants
{
    public static readonly string DataFolder =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

    public static readonly string ExtensionsFile =
        Path.Combine(DataFolder, "Extensions.txt");
}