using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
	public struct Vector4
	{
		float x, y, z, w;

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
			Vector4 result;
			result.x = _vec1.x + _vec2.x;
			result.y = _vec1.y + _vec2.y;
			result.z = _vec1.z + _vec2.z;
			result.w = _vec1.w + _vec2.w;

			return result;
		}

		//V = V - V
		public static Vector4 operator -(Vector4 _vec1, Vector4 _vec2)
		{
			Vector4 result;
			result.x = _vec1.x - _vec2.x;
			result.y = _vec1.y - _vec2.y;
			result.z = _vec1.z - _vec2.z;
			result.w = _vec1.w - _vec2.w;

			return result;
		}

		// V = V * f
		public static Vector4 operator *(Vector4 _vec, float _float)
		{
			Vector4 result;
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;
			result.w = _vec.w * _float;

			return result;
		}

		// V = f * V
		public static Vector4 operator *(float _float, Vector4 _vec)
		{
			Vector4 result;
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;
			result.w = _vec.w * _float;

			return result;
		}
	}
}
