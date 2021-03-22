using System;
using System.Collections.Generic;
using System.Text;

namespace MathClasses
{
	public struct Vector4
	{
		public float x, y, z, w;

		//constructor
		public Vector4(float _x = 0.0f, float _y = 0.0f, float _z = 0.0f, float _w = 0.0f)
		{
			x = _x;
			y = _y;
			z = _z;
			w = _w;
		}

		// -- // -- //
		//Operator Overloading
		// -- // -- //

		//V = V + V
		public static Vector4 operator +(Vector4 _vec1, Vector4 _vec2)
		{
			Vector4 result = new Vector4();
			result.x = _vec1.x + _vec2.x;
			result.y = _vec1.y + _vec2.y;
			result.z = _vec1.z + _vec2.z;
			result.w = _vec1.w + _vec2.w;

			return result;
		}

		//V = V - V
		public static Vector4 operator -(Vector4 _vec1, Vector4 _vec2)
		{
			Vector4 result = new Vector4();
			result.x = _vec1.x - _vec2.x;
			result.y = _vec1.y - _vec2.y;
			result.z = _vec1.z - _vec2.z;
			result.w = _vec1.w - _vec2.w;

			return result;
		}

		// V = V * f
		public static Vector4 operator *(Vector4 _vec, float _float)
		{
			Vector4 result = new Vector4();
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;
			result.w = _vec.w * _float;

			return result;
		}

		// V = f * V
		public static Vector4 operator *(float _float, Vector4 _vec)
		{
			Vector4 result = new Vector4();
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;
			result.w = _vec.w * _float;

			return result;
		}

		//Member variables
		public float Magnitude()
		{
			return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
		}

		public void Normalize()
		{
			float magnitude = Magnitude();
			x /= magnitude;
			y /= magnitude;
			z /= magnitude;
			w /= magnitude;
		}

		public float Dot(Vector4 _vec)
		{
			return x * _vec.x + y * _vec.y + z * _vec.z + w * _vec.w;
		}

		public Vector4 Cross(Vector4 _vec)
		{
			Vector4 result = new Vector4();
			result.x = y * _vec.z - z * _vec.y;
			result.y = z * _vec.x - x * _vec.z;
			result.z = x * _vec.y - y * _vec.x;
			result.w = 0;

			return result;
		}
	}
}
