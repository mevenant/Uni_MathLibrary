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
		public float[] m;

		public Matrix4(bool _default = true)
		{
			m = new float[16];
			m[0] = 1;
			m[1] = 0;
			m[2] = 0;
			m[3] = 0;
			m[4] = 0;
			m[5] = 1;
			m[6] = 0;
			m[7] = 0;
			m[8] = 0;
			m[9] = 0;
			m[10] = 1;
			m[11] = 0;
			m[12] = 0;
			m[13] = 0;
			m[14] = 0;
			m[15] = 1;
		}

		public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
		{
			m = new float[16];
			m[0] = m1;
			m[1] = m2;
			m[2] = m3;
			m[3] = m4;
			m[4] = m5;
			m[5] = m6;
			m[6] = m7;
			m[7] = m8;
			m[8] = m9;
			m[9] = m10;
			m[10] = m11;
			m[11] = m12;
			m[12] = m13;
			m[13] = m14;
			m[14] = m15;
			m[15] = m16;
		}

		public static Vector4 operator*(Matrix4 lhs, Vector4 rhs)
		{
			Vector4 result = new Vector4();

			return result;
		}

		public static Matrix4 operator*(Matrix4 a, Matrix4 b)
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

			result.m[0] = a.m[0] * b.m[0] + a.m[4] * b.m[1] + a.m[8]  * b.m[2] + a.m[12] * b.m[3];
			result.m[1] = a.m[1] * b.m[0] + a.m[5] * b.m[1] + a.m[9]  * b.m[2] + a.m[13] * b.m[3];
			result.m[2] = a.m[2] * b.m[0] + a.m[6] * b.m[1] + a.m[10] * b.m[2] + a.m[14] * b.m[3];
			result.m[3] = a.m[3] * b.m[0] + a.m[7] * b.m[1] + a.m[11] * b.m[2] + a.m[15] * b.m[3];

			result.m[4] = a.m[0] * b.m[4] + a.m[4] * b.m[5] + a.m[8]  * b.m[6] + a.m[12] * b.m[7];
			result.m[5] = a.m[1] * b.m[4] + a.m[5] * b.m[5] + a.m[9]  * b.m[6] + a.m[13] * b.m[7];
			result.m[6] = a.m[2] * b.m[4] + a.m[6] * b.m[5] + a.m[10] * b.m[6] + a.m[14] * b.m[7];
			result.m[7] = a.m[3] * b.m[4] + a.m[7] * b.m[5] + a.m[11] * b.m[6] + a.m[15] * b.m[7];

			result.m[8] = a.m[0] * b.m[8] + a.m[4] * b.m[9] + a.m[8]  * b.m[10] + a.m[12] * b.m[11];
			result.m[9] = a.m[1] * b.m[8] + a.m[5] * b.m[9] + a.m[9]  * b.m[10] + a.m[13] * b.m[11];
			result.m[10] = a.m[2] * b.m[8] + a.m[6] * b.m[9] + a.m[10] * b.m[10] + a.m[14] * b.m[11];
			result.m[11] = a.m[3] * b.m[8] + a.m[7] * b.m[9] + a.m[11] * b.m[10] + a.m[15] * b.m[11];

			result.m[12] = a.m[1] * b.m[12] + a.m[5] * b.m[13] + a.m[9]  * b.m[14] + a.m[13] * b.m[15];
			result.m[13] = a.m[0] * b.m[12] + a.m[4] * b.m[13] + a.m[8]  * b.m[14] + a.m[12] * b.m[15];
			result.m[14] = a.m[2] * b.m[12] + a.m[6] * b.m[13] + a.m[10] * b.m[14] + a.m[14] * b.m[15];
			result.m[15] = a.m[3] * b.m[12] + a.m[7] * b.m[13] + a.m[11] * b.m[14] + a.m[15] * b.m[15];

			return result;
		}

		
		public void SetRotationX(float _radians)
		{
			m[0] = 1;
			m[1] = 0;
			m[2] = 0;
			m[3] = 0;
			m[4] = 0;
			m[5] = (float)Math.Cos(_radians);
			m[6] = -(float)Math.Sin(_radians);
			m[7] = 0;
			m[8] = 0;
			m[9] = (float)Math.Sin(_radians);
			m[10] = (float)Math.Cos(_radians);
			m[11] = 0;
			m[12] = 0;
			m[13] = 0;
			m[14] = 0;
			m[15] = 1;
		}

		
		
		public void SetRotationY(float _radians)
		{
			m[0] = (float)Math.Cos(_radians);
			m[1] = 0;
			m[2] = (float)Math.Sin(_radians);
			m[3] = 0;
			m[4] = 0;
			m[5] = 1;
			m[6] = 0;
			m[7] = 0;
			m[8] = -(float)Math.Sin(_radians);
			m[9] = 0;
			m[10] = (float)Math.Cos(_radians);
			m[11] = 0;
			m[12] = 0;
			m[13] = 0;
			m[14] = 0;
			m[15] = 1;
		}

		public void SetRotationZ(float _radians)
		{
			m[0] = (float)Math.Cos(_radians);
			m[1] = -(float)Math.Sin(_radians);
			m[2] = 0;
			m[3] = 0;
			m[4] = (float)Math.Sin(_radians);
			m[5] = (float)Math.Cos(_radians);
			m[6] = 0;
			m[7] = 0;
			m[8] = 0;
			m[9] = 0;
			m[10] = 1;
			m[11] = 0;
			m[12] = 0;
			m[13] = 0;
			m[14] = 0;
			m[15] = 1;
		}
	}
}
