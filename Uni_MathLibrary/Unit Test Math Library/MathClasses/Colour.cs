using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
	public struct Colour
	{
		const int BY_ONE = 8;
		const int BY_TWO = 16;
		const int BY_THREE = 24;

		public uint colour; //4 byte integer

		public Colour(byte red, byte green, byte blue, byte alpha)
		{
			//0x00 00 00 00
			//00 00 00 00
			//r  g  b  a
			colour = (uint)((red << 24) | (green << 16) | (blue << 8) | alpha);
			//moving across         3               2              1    bytes
			//colour = (uint)((red << 24) + (green << 16) + (blue << 8) + alpha); also valid
		}

		public void SetRed(byte _value)
		{
			//RGBA
			colour &= 0x00FFFFFF;
			colour |= (uint)(_value << BY_THREE);
		}

		public void SetGreen(byte _value)
		{
			//RGBA
			colour &= 0xFF00FFFF;
			colour |= (uint)(_value << BY_TWO);
		}

		public void SetBlue(byte _value)
		{
			//RGBA
			colour &= 0xFFFF00FF;
			colour |= (uint)(_value << BY_ONE);
		}

		public void SetAlpha(byte _value)
		{
			colour &= 0xFFFFFF00;
			colour |= (uint)_value;
		}

		public byte GetRed()
		{
			return (byte)(colour >> 24);
		}

		public byte GetGreen()
		{
			return (byte)((colour << BY_ONE) >> BY_THREE);
		}

		public byte GetBlue()
		{
			return (byte)((colour << BY_TWO) >> BY_THREE);
		}

		public byte GetAlpha()
		{
			return (byte)((colour << BY_THREE) >> BY_THREE);
		}
	}
}
