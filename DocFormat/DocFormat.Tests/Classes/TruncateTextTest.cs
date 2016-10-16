using System;
using DocFormat.Core.Classes;
using Xunit;

namespace DocFormat.Core.Tests.Classes
{
    public class TruncateTextTest
    {
        [Fact]
        public void TruncateWithStringTruncatesIt()
        {
            // Fixture setup
            var sut = new TrucateText();

            // Exercise system
            var result = sut.Truncate("Hello world!", 5);

            // Verify outcome
            Assert.Equal(5, result.Length);

            // Teardown
        }

        [Fact]
        public void TruncateWithNullThrowsException()
        {
            // Fixture setup
            var sut = new TrucateText();

            // Exercise system
            Assert.Throws<ArgumentNullException>(() => sut.Truncate(null, 0));

            // Verify outcome

            // Teardown
        }
    }
}
