using System.Collections.Generic;
using System.Linq;

namespace DocFormat.Core.Documents
{
    public class Document
    {
        private readonly DocumentLine[] _documentLines;

        public Document(params DocumentLine[] documentLines)
        {
            _documentLines = documentLines;
        }

        public int ItemCount => _documentLines.Length;

        public string[] GetHeaders()
        {
            var hashSet = new HashSet<string>();

            foreach (var line in _documentLines)
            {
                hashSet.UnionWith(line.Headers);
            }

            return hashSet.ToArray();
        }

        public DocumentLine GetLine(int index)
        {
            return _documentLines[index];
        }

        public DocumentLine[] GetLines() => _documentLines;
    }
}