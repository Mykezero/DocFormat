namespace DocFormat.Core.Classes
{
    public class EscapeText
    {
        public string Escape(string value)
        {
            return value.Replace(@"""", @"""""");
        }
    }
}
