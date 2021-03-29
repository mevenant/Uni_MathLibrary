using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
	public struct Matrix3
	{
		public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
		//Note that even though this is a struct, 
		public Matrix3(bool identity)
		{
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 1;
			m6 = 0;
			m7 = 0;
			m8 = 0;
			m9 = 1;
		}

		public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
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
		}

		public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
		{
			Vector3 result = new Vector3();
			result.x = (lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z);
			result.y = (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z);
			result.z = (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z);

			return result;
		}

		public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
		{
			Matrix3 result = new Matrix3();

			// this is an indication of which indices must be multiplied and added together
			//       | 0 3 6 | | 0 3 6 | 
			// lhs = | 1 4 7 | | 1 4 7 | = result
			//       | 2 5 8 | | 2 5 8 |
			//                 ---------
			//                 | 0 3 6 |
			// rhs =		   | 1 4 7 |
			//			       | 2 5 8 |

			result.m1 = lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3;
			result.m2 = lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3;
			result.m3 = lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3;

			result.m4 = lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6;
			result.m5 = lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6;
			result.m6 = lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6;

			result.m7 = lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9;
			result.m8 = lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9;
			result.m9 = lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9;

			return result;
		}

		//float[] b must be of size 9 or the program will crash
		public static Matrix3 operator *(Matrix3 lhs, float[] rhs)
		{
			Matrix3 result = new Matrix3();

			// this is an indication of which indices must be multiplied and added together
			//       | 0 3 6 | | 0 3 6 | 
			// lhs = | 1 4 7 | | 1 4 7 | = result
			//       | 2 5 8 | | 2 5 8 |
			//                 ---------
			//                 | 0 3 6 |
			// rhs =		   | 1 4 7 |
			//			       | 2 5 8 |

			result.m1 = lhs.m1 * rhs[0] + lhs.m4 * rhs[1] + lhs.m7 * rhs[2];
			result.m2 = lhs.m2 * rhs[0] + lhs.m5 * rhs[1] + lhs.m8 * rhs[2];
			result.m3 = lhs.m3 * rhs[0] + lhs.m6 * rhs[1] + lhs.m9 * rhs[2];

			result.m4 = lhs.m1 * rhs[3] + lhs.m4 * rhs[4] + lhs.m7 * rhs[5];
			result.m5 = lhs.m2 * rhs[3] + lhs.m5 * rhs[4] + lhs.m8 * rhs[5];
			result.m6 = lhs.m3 * rhs[3] + lhs.m6 * rhs[4] + lhs.m9 * rhs[5];

			result.m7 = lhs.m1 * rhs[6] + lhs.m4 * rhs[7] + lhs.m7 * rhs[8];
			result.m8 = lhs.m2 * rhs[6] + lhs.m5 * rhs[7] + lhs.m8 * rhs[8];
			result.m9 = lhs.m3 * rhs[6] + lhs.m6 * rhs[7] + lhs.m9 * rhs[8];

			return result;
		}

		//Reset to identity matrix
		public void Reset()
		{
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 1;
			m6 = 0;
			m7 = 0;
			m8 = 0;
			m9 = 1;
		}

		//Rotate around X
		public void SetRotateX(float _radians)
		{
			//X doesn't change
			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = (float)Math.Cos(_radians);
			m6 = (float)Math.Sin(_radians);
			m7 = 0;
			m8 = -(float)Math.Sin(_radians);
			m9 = (float)Math.Cos(_radians);
		}

		//Rotate around Y
		public void SetRotateY(float _radians)
		{
			//Y doesn't change
			m1 = (float)Math.Cos(_radians);
			m2 = 0;
			m3 = -(float)Math.Sin(_radians);
			m4 = 0;
			m5 = 1;
			m6 = 0;
			m7 = (float)Math.Sin(_radians);
			m8 = 0;
			m9 = (float)Math.Cos(_radians);
		}

		//Rotate aruond Z
		public void SetRotateZ(float _radians)
		{
			//Z doesn't change
			m1 = (float)Math.Cos(_radians);
			m2 = (float)Math.Sin(_radians);
			m3 = 0;
			m4 = -(float)Math.Sin(_radians);
			m5 = (float)Math.Cos(_radians);
			m6 = 0;
			m7 = 0;
			m8 = 0;
			m9 = 1;
		}

		public void SetScale(float _scale)
		{
			Matrix3 scale_matrix = new Matrix3();
			scale_matrix.m1 = _scale;
			scale_matrix.m2 = _scale;
			this = this * scale_matrix;
		}

		public void SetScale(Vector2 _scale)
		{
			Matrix3 scale_matrix = new Matrix3();
			scale_matrix.m1 = _scale.x;
			scale_matrix.m2 = _scale.y;
			this = this * scale_matrix;
		}

		public void SetPosition(Vector3 _position_vector)
		{
			m7 = _position_vector.x;
			m8 = _position_vector.y;
		}

		public void SetPosition(Vector2 _position_vector)
		{
			m7 = _position_vector.x;
			m8 = _position_vector.y;
		}

		public Vector2 GetPosition()
		{
			return new Vector2(m7, m8);
		}

		public Vector2 GetUp()
		{
			var result = new Vector2(m4, m5);
			result.Normalize();
			return result;
		}

		public Vector2 GetRight()
		{
			var result = new Vector2(m1, m2);
			result.Normalize();
			return result;
		}
	}
}
