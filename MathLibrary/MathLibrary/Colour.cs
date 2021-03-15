using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
	struct Colour
	{
		private uint colour;	//4 byte integer
		
		public Colour(byte red, byte green, byte blue, byte alpha)
		{
			//0x00 00 00 00
			//00 00 00 00
			//r  g  b  a
			colour = (uint)((red << 24) | (green << 16) | (blue << 8) | alpha);
			//moving across         3               2              1    bytes
			//colour = (uint)((red << 24) + (green << 16) + (blue << 8) + alpha); also valid
		}

		public void SetRed(byte red)
		{
			colour &= 0xFF000000;
			colour |= (uint)(red << 24);
		}

		public byte GetRed()
		{
			return (byte)(colour >> 24);
		}

		public byte GetGreen()
		{
			return (byte)((colour << 8) >> 24);
		}
	}
}
