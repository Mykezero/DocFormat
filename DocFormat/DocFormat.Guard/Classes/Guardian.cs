using System;

namespace DocFormat.Guard.Classes
{
    public static class Guardian
    {
        public static Exception CastNullBarrier(object value)
        {
            if (value != null) return null;
            if (!StandDown) throw new ArgumentNullException();
            return new ArgumentNullException();
        }

        public static bool StandDown { get; set; }
    }
}
