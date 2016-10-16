using System.Linq;
using DocFormat.Core.Documents;
using DocFormat.Core.Exceptions;
using DocFormat.Core.Fields;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace DocFormat.Core.Tests.Documents
{
    public class DocumentProcessorTest
    {
        [Theory]
        [InlineAutoData(0, false)]
        [InlineAutoData(1, true)]
        [InlineAutoData(3, true)]
        public void StartWithDocumentContainingLinesRaisesOnStartCorrectly(int count, bool expected, Generator<DocumentLine> items)
        {
            // Fixture setup
            var document = new Document(items.Take(count).ToArray());

            var sut = new DocumentProcessor();
            bool result = false;

            // Exercise system         
            sut.OnStart += () => result = true;
            sut.Start(document);

            // Verify outcome            
            Assert.Equal(expected, result);

            // Teardown
        }

        [Fact]
        public void StartWillFormatAllDocumentLines()
        {
            // Fixture setup
            var document = new Document(
                new DocumentLine(
                    new TruncatedDocumentField(
                        "Description",
                        "The is a very long description.",
                        10)));

            // Exercise system
            var sut = new DocumentProcessor();
            sut.Start(document);

            // Verify outcome
            var result = document
                .GetLine(0)
                .GetFieldValueByHeader<string>("Description");

            Assert.Equal(10, result.Length);

            // Teardown
        }

        [Fact]
        public void StartWithDocumentContainingLinesWithDifferentFieldAmountsThrowsException()
        {
            // Fixture setup
            var document = new Document(
                new DocumentLine(
                    new DocumentField(null, null)),
                new DocumentLine());

            var sut = CreateSut();

            // Exercise system            
            Assert.Throws<DocumentFieldMissingException>(() => sut.Start(document));

            // Verify outcome
            // Teardown
        }        

        [Fact]
        public void StartWithItemsWillRaiseOnProgressEvent()
        {
            // Fixture setup
            var sut = CreateSut();

            bool result = false;
            sut.OnProgress += line => result = true;
            var document = DocumentLocator.FindDocument();

            // Exercise system
            sut.Start(document);

            // Verify outcome
            Assert.True(result);

            // Teardown
        }

        [Fact]
        public void StartWithItemsWillRaiseOnEndEvent()
        {
            // Fixture setup
            var sut = CreateSut();

            bool result = false;
            sut.OnEnd += () => result = true;
            var document = DocumentLocator.FindDocument();

            // Exercise system
            sut.Start(document);

            // Verify outcome
            Assert.True(result);

            // Teardown
        }

        [Fact]
        public void StartWithNoLinesDoesNotRaiseStartEvent()
        {
            // Fixture setup
            var sut = CreateSut();
            var result = false;
            sut.OnStart += () => result = true;

            // Exercise system            
            sut.Start(new Document());

            // Verify outcome
            Assert.False(result);

            // Teardown
        }

        private static DocumentProcessor CreateSut()
        {
            return new DocumentProcessor();
        }
    }
}
