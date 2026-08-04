using System.Windows.Forms;

namespace RetroBatGameListComparator.Helpers;

public class ExtensionAutoCompleteHelper
{
    private readonly ComboBox _comboBox;

    private readonly List<string> _extensions;

    public ExtensionAutoCompleteHelper(
        ComboBox comboBox,
        IEnumerable<string> extensions)
    {
        _comboBox = comboBox;

        _extensions = extensions
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x)
            .ToList();
    }
}