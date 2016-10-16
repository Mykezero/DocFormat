using DocFormat.Core.Documents;

namespace DocFormat.Core.Tests.Documents
{
    public static class DocumentLocator
    {
        public static Document FindDocument()
        {
            var document = new Document(
                new DocumentLine(
                    new DocumentField("Sku", "SKUABC123"),
                    new DocumentField("Price", 100m),
                    new DocumentField("Description", "The is a very long description."),
                    new DocumentField("IsNew", true)));
            return document;
        }
    }
}