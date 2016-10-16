using System;
using System.Collections.Generic;
using System.Linq;

namespace DocFormat.Core.Documents
{
    public class DocumentLine
    {
        public DocumentLine(params DocumentField[] documentFields)
        {
            Fields = documentFields.ToList();
        }

        public string[] Headers => Fields.Select(x => x.Header).ToArray();

        public IList<DocumentField> Fields { get; }

        public T GetFieldValueByHeader<T>(string header)
        {
            var fieldDictionary = Fields.ToDictionary(x => x.Header, x => x.Value);
            if (!fieldDictionary.ContainsKey(header)) throw new KeyNotFoundException($"No field exists with header {header}");

            var value = fieldDictionary[header];
            if (!(value is T)) throw new InvalidCastException($"DocumentField with header {header} could not be casted to type {typeof(T)}");

            return (T) value;
        }
    }
}