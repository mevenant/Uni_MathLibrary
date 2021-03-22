using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
	// | 0 4 8  12 |
	// | 1 5 9  13 |
	// | 2 6 10 14 |
	// | 3 7 11 15 |
	public struct Matrix4
	{
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

		public Matrix4(bool _default)
		{
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 0;
			m6 = 1;
			m7 = 0;
			m8 = 0;
			m9 = 0;
			m10 = 0;
			m11 = 1;
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}

		public Matrix4(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
		{
			m1 = _m1;
			m2 = _m2;
			m3 = _m3;
			m4 = _m4;
			m5 = _m5;
			m6 = _m6;
			m7 = _m7;
			m8 = _m8;
			m9 = _m9;
			m10 = _m10;
			m11 = _m11;
			m12 = _m12;
			m13 = _m13;
			m14 = _m14;
			m15 = _m15;
			m16 = _m16;
		}

		public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
		{
			Vector4 result = new Vector4();

			result.x = (lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w);
			result.y = (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w);
			result.z = (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w);
			result.w = (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w);

			return result;
		}

		public static Matrix4 operator *(Matrix4 a, Matrix4 b)
		{
			Matrix4 result = new Matrix4();

			// | 0 4 8  12 | - | 0 4 8  12 | 
			// | 1 5 9  13 | - | 1 5 9  13 |
			// | 2 6 10 14 | - | 2 6 10 14 |
			// | 3 7 11 15 | - | 3 7 11 15 |
			//                   - - -  -
			//                 | 0 4 8  12 |
			//                 | 1 5 9  13 |
			//                 | 2 6 10 14 |
			//                 | 3 7 11 15 |

			result.m1  = a.m1 * b.m1 + a.m5 * b.m2 + a.m9  * b.m3 + a.m13 * b.m4;
			result.m2  = a.m2 * b.m1 + a.m6 * b.m2 + a.m10 * b.m3 + a.m14 * b.m4;
			result.m3  = a.m3 * b.m1 + a.m7 * b.m2 + a.m11 * b.m3 + a.m15 * b.m4;
			result.m4  = a.m4 * b.m1 + a.m8 * b.m2 + a.m12 * b.m3 + a.m16 * b.m4;

			result.m5  = a.m1 * b.m5 + a.m5 * b.m6 + a.m9  * b.m7 + a.m13 * b.m8;
			result.m6  = a.m2 * b.m5 + a.m6 * b.m6 + a.m10 * b.m7 + a.m14 * b.m8;
			result.m7  = a.m3 * b.m5 + a.m7 * b.m6 + a.m11 * b.m7 + a.m15 * b.m8;
			result.m8  = a.m4 * b.m5 + a.m8 * b.m6 + a.m12 * b.m7 + a.m16 * b.m8;

			result.m9  = a.m1 * b.m9 + a.m5 * b.m10 + a.m9  * b.m11 + a.m13 * b.m12;
			result.m10 = a.m2 * b.m9 + a.m6 * b.m10 + a.m10 * b.m11 + a.m14 * b.m12;
			result.m11 = a.m3 * b.m9 + a.m7 * b.m10 + a.m11 * b.m11 + a.m15 * b.m12;
			result.m12 = a.m4 * b.m9 + a.m8 * b.m10 + a.m12 * b.m11 + a.m16 * b.m12;

			result.m13 = a.m1 * b.m13 + a.m5 * b.m14 + a.m9  * b.m15 + a.m13 * b.m16;
			result.m14 = a.m2 * b.m13 + a.m6 * b.m14 + a.m10 * b.m15 + a.m14 * b.m16;
			result.m15 = a.m3 * b.m13 + a.m7 * b.m14 + a.m11 * b.m15 + a.m15 * b.m16;
			result.m16 = a.m4 * b.m13 + a.m8 * b.m14 + a.m12 * b.m15 + a.m16 * b.m16;

			return result;
		}


		public void SetRotateX(float _radians)
		{
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 0;
			m6 = (float)Math.Cos(_radians);
			m7 = (float)Math.Sin(_radians);
			m8 = 0;
			m9 = 0;
			m10 = -(float)Math.Sin(_radians);
			m11 = (float)Math.Cos(_radians);
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}



		public void SetRotateY(float _radians)
		{
			m1 = (float)Math.Cos(_radians);
			m2 = 0;
			m3 = -(float)Math.Sin(_radians);
			m4 = 0;
			m5 = 0;
			m6 = 1;
			m7 = 0;
			m8 = 0;
			m9 = (float)Math.Sin(_radians);
			m10 = 0;
			m11 = (float)Math.Cos(_radians);
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}

		public void SetRotateZ(float _radians)
		{
			m1 = (float)Math.Cos(_radians);
			m2 = (float)Math.Sin(_radians);
			m3 = 0;
			m4 = 0;
			m5 = -(float)Math.Sin(_radians);
			m6 = (float)Math.Cos(_radians);
			m7 = 0;
			m8 = 0;
			m9 = 0;
			m10 = 0;
			m11 = 1;
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}
	}
}
