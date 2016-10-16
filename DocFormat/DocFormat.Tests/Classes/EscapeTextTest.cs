using DocFormat.Core.Classes;
using Xunit;

namespace DocFormat.Core.Tests.Classes
{
    public class EscapeTextTest
    {
        [Fact]
        public void FormatWithQuotedTextEscapesIt()
        {
            // Fixture setup
            var value = @"""Hello, World!""";
            var sut = new EscapeText();

            // Exercise system
            var result = sut.Escape(value);

            // Verify outcome
            AssertNotEscaped(result);

            // Teardown
        }

        private void AssertNotEscaped(string arg)
        {
            var result = arg.Replace(@"""""", "");
            Assert.True(!result.Contains(@""""), $"Text {arg} is not escaped.");
        }
    }
}
