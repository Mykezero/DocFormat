using System.Linq;
using System.Runtime.InteropServices;
using DocFormat.Core.Classes;
using DocFormat.Core.Documents;

namespace DocFormat.Core.Formatters
{
    /// <summary>
    /// Escape all text within the document. 
    /// </summary>
    public class EscapeTextDocumentFormatter
    {
        private readonly EscapeText _escapeText = new EscapeText();

        public void Format(Document document)
        {
            for (int i = 0; i < document.ItemCount; i++)
            {
                var item = document.GetLine(i);
                var fields = item.Fields.Where(x => x.Value is string).ToArray();
                foreach (var field in fields)
                {
                    field.Value = _escapeText.Escape((string) field.Value);
                }
            }
        }
    }
}