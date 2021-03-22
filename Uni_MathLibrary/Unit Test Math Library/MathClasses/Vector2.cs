using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
	public struct Vector2
	{
		public float x, y;
		public static Vector2 ZERO = new Vector2();
		//constructor
		public Vector2(float _x = 0.0f, float _y = 0.0f)
		{
			x = _x;
			y = _y;
		}

		// -- // -- //
		//Operator Overloading
		// -- // -- //

		//V = V + V
		public static Vector2 operator +(Vector2 _vec1, Vector2 _vec2)
		{
			Vector2 result = new Vector2();
			result.x = _vec1.x + _vec2.x;
			result.y = _vec1.y + _vec2.y;

			return result;
		}

		//V = V - V
		public static Vector2 operator -(Vector2 _vec1, Vector2 _vec2)
		{
			Vector2 result = new Vector2();
			result.x = _vec1.x - _vec2.x;
			result.y = _vec1.y - _vec2.y;

			return result;
		}

		// V = V * f
		public static Vector2 operator *(Vector2 _vec, float _float)
		{
			Vector2 result = new Vector2();
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;

			return result;
		}

		// V = f * V
		public static Vector2 operator *(float _float, Vector2 _vec)
		{
			Vector2 result = new Vector2();
			result.x = _vec.x * _float;
			result.y = _vec.y * _float;

			return result;
		}

		public static bool operator ==(Vector2 _vec1, Vector2 _vec2)
		{
			return (_vec1.x == _vec2.x) && (_vec1.y == _vec2.y);
		}

		public static bool operator !=(Vector2 _vec1, Vector2 _vec2)
		{
			return (_vec1.x != _vec2.x) || (_vec1.y != _vec2.y);
		}

		//Member methods
		public float Magnitude()
		{
			return (float)Math.Sqrt(x * x + y * y);
		}

		public void Normalize()
		{
			float magnitude = Magnitude();

			if (magnitude != 0)
			{
				x /= magnitude;
				y /= magnitude;
			}
		}

		public float Dot(Vector2 _vec)
		{
			return x * _vec.x + y * _vec.y;
		}

		public void Rotate(float _radians)
		{
			x = (float)Math.Cos(_radians);
			y = (float)Math.Sin(_radians);
		}


		public float NormalizeAndDot(Vector2 _vec)
		{
			var normalized = new Vector2(x, y);
			return normalized.x * _vec.x + normalized.y * _vec.y;
		}

		//This function only works in 2D
		public Vector2 GetPerpendicular()
		{
			Vector2 result;
			result.x = -y;
			result.y = x;
			return result;
		}

		public float GetAngle()
		{
			//float A = Dot(new Vector2(1, 0));
			//return (float)Math.Acos(A / Magnitude());

			return GetAngleBetween(this, new Vector2(1, 0));
		}

		public static float GetAngleBetween(Vector2 _vec1, Vector2 _vec2)
		{
			//Get the dot product of our two vectors
			_vec1.Normalize();
			_vec2.Normalize();
			float fDot = _vec1.Dot(_vec2);

			//Get angle
			float angle = (float)Math.Acos(fDot);

			//Get the dot product of one of the vectors and another vector at right angles
			Vector2 rightAngle = _vec1.GetPerpendicular();
			float fRightDot = _vec1.Dot(rightAngle);
			
			if (fRightDot < 0)
				angle = angle * -1f;

			return angle;

		}

		public float GetAngleDegree()
		{
			return GetAngle() * 180 / (float)Math.PI;
		}
	}
}
