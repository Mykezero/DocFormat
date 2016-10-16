namespace DocFormat.Core.Documents
{
    public class DocumentField
    {
        public DocumentField(string header, object value)
        {
            Header = header;
            Value = value;
        }

        public string Header { get; }
        public object Value { get; set; }

        public virtual void Format()
        {
        }
    }
}