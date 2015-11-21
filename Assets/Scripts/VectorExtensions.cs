using UnityEngine;
using System.Collections;

namespace GameFoundations
{
	public static class VectorExtensions
	{
		public static Vector2 xy (this Vector3 v)
		{
			return new Vector2 (v.x, v.y);
		}
		
		public static Vector3 WithX (this Vector3 v, float x)
		{
			return new Vector3 (x, v.y, v.z);
		}
		
		public static Vector3 WithY (this Vector3 v, float y)
		{
			return new Vector3 (v.x, y, v.z);
		}
		
		public static Vector3 WithZ (this Vector3 v, float z)
		{
			return new Vector3 (v.x, v.y, z);
		}
		
		public static Vector2 WithX (this Vector2 v, float x)
		{
			return new Vector2 (x, v.y);
		}
		
		public static Vector2 WithY (this Vector2 v, float y)
		{
			return new Vector2 (v.x, y);
		}
		
		public static Vector3 WithZ (this Vector2 v, float z)
		{
			return new Vector3 (v.x, v.y, z);
		}
		
		public static Vector2 AddRandomOffset (this Vector2 start, float xOffset, float yOffset)
		{
			return new Vector2 (start.x + Random.Range (-xOffset, xOffset), start.y + Random.Range (-yOffset, yOffset));
		}
		
		public static Vector2 AddRandomOffset (this Vector2 start, Vector2 offset)
		{
			return new Vector2 (start.x + Random.Range (-offset.x, offset.x), start.y + Random.Range (-offset.y, offset.y));
		}

		public static Vector2 MidPoint (this Vector2 first, Vector2 second)
		{
			return new Vector3 ((first.x + second.x) * 0.5f, (first.y + second.y) * 0.5f);
		}

		public static Vector3 MidPoint (this Vector3 first, Vector3 second)
		{
			return new Vector3 ((first.x + second.x) * 0.5f, (first.y + second.y) * 0.5f, (first.z + second.z) * 0.5f);
		}

		public static Vector2 Abs (this Vector2 v)
		{
			return new Vector3 (Mathf.Abs (v.x), Mathf.Abs (v.y));
		}

		public static Vector3 Abs (this Vector3 v)
		{
			return new Vector3 (Mathf.Abs (v.x), Mathf.Abs (v.y), Mathf.Abs (v.z));
		}

		public static bool IsNaN (this Vector2 vec)
		{
			return float.IsNaN (vec.x * vec.y);
		}

		public static bool IsNaN (this Vector3 vec)
		{
			return float.IsNaN (vec.x * vec.y * vec.z);
		}

	}
}
