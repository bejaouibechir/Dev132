using System.Collections;
using System.IO;
using System.Text;

namespace Doranco132.Console
{
    public static class EnmerableExtesnion
    {
        static public void PersistToFile(this IEnumerable collection,string path)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in collection)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            string content = stringBuilder.ToString();
            File.WriteAllText(path,content);

        }
    }
}
