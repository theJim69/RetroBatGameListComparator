using System.Xml.Linq;
using RetroBatGameListComparator.Models;

namespace RetroBatGameListComparator.Services;

public class XmlReaderService
{
    public List<RomEntry> Read(
        string xmlFile,
        string romFolder)
    {
        XDocument document = XDocument.Load(xmlFile);

        return document
            .Descendants("path")
            .Select(path => path.Value.Trim())
            .Where(path => !string.IsNullOrWhiteSpace(path))
            .Select(path =>
            {
                string relativePath = path.Replace("./", "");

                return new RomEntry
                {
                    FileName = Path.GetFileName(relativePath),

                    RelativePath = relativePath,

                    FullPath = Path.Combine(
                        romFolder,
                        relativePath)
                };
            })
            .OrderBy(x => x.FileName)
            .ToList();
    }
}