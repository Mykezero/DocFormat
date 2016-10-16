using System;
using System.Linq;
using DocFormat.Core.Exceptions;

namespace DocFormat.Core.Documents
{
    public class DocumentProcessor
    {
        public void Start(Document document)
        {
            var hasItems = document.ItemCount > 0;
            if (!hasItems) return;

            OnStart?.Invoke();

            var lines = document.GetLines();            

            var fieldCountsMatch = ItemFieldCountsMatch(lines);
            if (!fieldCountsMatch) throw new DocumentFieldMissingException();

            FormatFields(lines);

            OnEnd?.Invoke();
        }

        private void FormatFields(DocumentLine[] documentLines)
        {
            foreach (var line in documentLines)
            {
                OnProgress?.Invoke(line);

                foreach (var field in line.Fields)
                {                    
                    field.Format();
                }
            }
        }

        private static bool ItemFieldCountsMatch(DocumentLine[] documentLines)
        {
            var maxFieldCount = documentLines
                .Max(x => x.Fields.Count);

            var minFieldCount = documentLines
                .Min(x => x.Fields.Count);

            var result = minFieldCount == maxFieldCount;
            return result;
        }

        public event Action OnStart;
        public event Action<DocumentLine> OnProgress;
        public event Action OnEnd;
    }
}