using System;

namespace ColourGuesser
{
    public class Colour
    {
        public string name;
        public int closeness = 0;
        public byte r, g, b;

        public Colour(string name, byte r, byte g, byte b, int closeness = 0)
        {
            this.name = name;
            this.closeness = closeness;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public int Compare(byte r, byte g, byte b)
        {
            return (Math.Abs(this.r - r) + Math.Abs(this.g - g) + Math.Abs(this.b - b));
        }
    }
}
