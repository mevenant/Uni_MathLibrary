using System;

namespace MathClasses
{
	public struct Vector3
	{
		public float x, y, z;

		//constructor
		public Vector3(float _x = 0.0f, float _y = 0.0f, float _z = 0.0f)
		{
			x = _x;
			y = _y;
			z = _z;
		}

		// -- // -- //
		//Operator Overloading
		// -- // -- //

		//V = V + V
		public static Vector3 operator+(Vector3 _vec1, Vector3 _vec2)
		{
			Vector3 result;
			result.x = _vec1.x + _vec2.x;
			result.y = _vec1.y + _vec2.y;
			result.z = _vec1.z + _vec2.z;

			return result;
		}
		
		//V = V - V
		public static Vector3 operator-(Vector3 _vec1, Vector3 _vec2)
		{
			Vector3 result;
			result.x = _vec1.x - _vec2.x;
			result.y = _vec1.y - _vec2.y;
			result.z = _vec1.z - _vec2.z;

			return result;
		}

		// V = V * f
		public static Vector3 operator*(Vector3 _vec, float _float)
		{
			Vector3 result;
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;

			return result;
		}

		// V = f * V
		public static Vector3 operator*(float _float, Vector3 _vec)
		{
			Vector3 result;
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;
			result.z = _vec.z * _float;

			return result;
		}

		//Member methods
		public float Magnitude()
		{
			return (float)Math.Sqrt(x * x + y * y + z * z);
		}

		public void Normalise()
		{
			float magnitude = Magnitude();

			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
				z /= magnitude;
			}
		}

		public Vector3 Cross(Vector3 _vec)
		{
			Vector3 result;
			result.x = y * _vec.z - z * _vec.y;
			result.y = z * _vec.x - x * _vec.z;
			result.z = x * _vec.y - y * _vec.x;
			return result;
		}
		
	}

	
}
