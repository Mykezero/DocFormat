using Xunit;

namespace DocFormat.Core.Tests.Documents
{
    public class DocumentTest
    {
        [Fact]
        public void DocumentContainsAllHeaders()
        {
            // Fixture setup
            var document = DocumentLocator.FindDocument();

            // Exercise system
            var headers = document.GetHeaders();

            // Verify outcome
            Assert.Equal("Sku", headers[0]);
            Assert.Equal("Price", headers[1]);
            // Teardown
        }

        [Fact]
        public void DocumentContainsAllFieldValues()
        {
            // Fixture setup
            var document = DocumentLocator.FindDocument();

            // Exercise system
            var documentLine = document.GetLine(0);

            // Verify outcome
            Assert.Equal(4, documentLine.Fields.Count);

            // Teardown
        }        
    }
}