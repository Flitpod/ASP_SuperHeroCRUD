using System.Reflection;
using System.Text;

namespace M3_SuperHeroCRUD.Helpers
{
    public class TableBuilder
    {
        public string BuildTable<T>(IEnumerable<T> collection)
        {
            StringBuilder sb = new StringBuilder();
            var props = typeof(T)
                .GetProperties()
                .Where(p => p.GetCustomAttribute<ShowTableAttribute>() != null);

            // table opening
            sb.Append("<table>");
            sb.Append("<tr>");

            // table header columns
            foreach (var prop in props)
            {
                sb.Append("<th>");
                sb.Append(prop.Name);
                sb.Append("</th>");
            }

            // fill table rows with data from items in collection
            foreach (T item in collection)
            {
                // row opening
                sb.Append("<tr>");

                foreach (var prop in props)
                {
                    sb.Append($"<td>");
                    sb.Append(prop.GetValue(item));
                    sb.Append($"</td>");
                }

                // row closing
                sb.Append("</tr>");
            }

            // table closing
            sb.Append("</tr>");
            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
