using System;
using DocFormat.Guard.Classes;
using Xunit;

namespace DocFormat.Guard.Tests.Classes
{
    public class GuardTest
    {
        [Fact]
        public void GuardianProtectsAgainstNulls()
        {
            object value = null;
            Assert.Throws<ArgumentNullException>(() => Guardian.CastNullBarrier(value));
        }

        [Fact]
        public void GuardianWithNullValueWhenStandingDownReturnsException()
        {
            // Fixture setup
            Guardian.StandDown = true;

            // Exercise system
            object value = null;
            var result = Guardian.CastNullBarrier(value);

            // Verify outcome
            Assert.IsType<ArgumentNullException>(result);

            // Teardown
            Guardian.StandDown = false;
        }
    }
}
