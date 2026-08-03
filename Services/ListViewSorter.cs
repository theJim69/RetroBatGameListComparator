using System.Collections;
using System.Windows.Forms;

namespace RetroBatGameListComparator;

public class ListViewSorter : IComparer
{
    public int Column { get; set; }

    public SortOrder Order { get; set; } = SortOrder.Ascending;

    public int Compare(object? x, object? y)
    {
        if (x is not ListViewItem item1 ||
            y is not ListViewItem item2)
            return 0;

        string value1 = item1.SubItems[Column].Text;
        string value2 = item2.SubItems[Column].Text;

        int result = string.Compare(
            value1,
            value2,
            StringComparison.CurrentCultureIgnoreCase);

        return Order == SortOrder.Ascending
            ? result
            : -result;
    }
}