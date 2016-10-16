using System.Linq;
using DocFormat.Core.Documents;
using DocFormat.Core.Formatters;
using Xunit;

namespace DocFormat.Core.Tests.Documents
{
    public class EscapeTextDocumentFormatterTest
    {
        [Fact]
        public void FormatWillEscapeDoubleQuotes()
        {
            // Fixture setup
            var document = FindDocument();

            // Exercise system
            var formatter = new EscapeTextDocumentFormatter();
            formatter.Format(document);

            var result = document.GetLines()
                .SelectMany(x => x.Fields)
                .Select(x => x.Value)
                .OfType<string>()
                .All(IsQuoted);

            // Verify outcome            
            Assert.True(result);
            // Teardown
        }

        private bool IsQuoted(string arg)
        {
            var result = arg.Replace(@"""""", "");
            return !result.Contains(@"""");
        }

        private static Document FindDocument()
        {
            var document = new Document(
                new DocumentLine(
                    new DocumentField("Size", "5\" x 8\"")));
            return document;
        }
    }
}
