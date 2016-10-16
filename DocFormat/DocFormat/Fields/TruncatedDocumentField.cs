using DocFormat.Core.Classes;
using DocFormat.Core.Documents;

namespace DocFormat.Core.Fields
{
    public class TruncatedDocumentField : DocumentField
    {
        private readonly TrucateText _formatter = 
            new TrucateText();

        private readonly int _length;

        public TruncatedDocumentField(string header, string value, int length) : base(header, value)
        {
            _length = length;
        }

        public override void Format()
        {
            Value = _formatter.Truncate((string) Value, _length);
        }
    }
}