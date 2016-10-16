using System.Linq;

namespace DocFormat.Core.Classes
{
    public class TrucateText
    {
        public string Truncate(string value, int length)
        {
            return string.Join("", value.Take(length));
        }
    }
}
