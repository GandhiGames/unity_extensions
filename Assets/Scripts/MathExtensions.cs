using UnityEngine;
using System;
using System.Collections;

namespace GameFoundations
{
	public static class MathExtensions
	{
		public static float InverseLerp (float from, float to, float value)
		{
			if (from < to) {
				if (value < from)
					return 0.0f;
				if (value > to)
					return 1.0f;
			} else {
				if (value < to)
					return 1.0f;
				if (value > from)
					return 0.0f;
			}
			return (value - from) / (to - from);
		}

		public static bool Approximately (this float a, float other)
		{
			return Mathf.Approximately (a, other);
		}
		
		/// <summary>
		/// is this float within range of other
		/// </summary>
		/// <param name="x"></param>
		/// <param name="other"></param>
		/// <param name="delta"></param>
		/// <returns></returns>
		public static bool Approximately (this float x, float other, float delta)
		{
			return Math.Abs (x - other) < delta;
		}
		
		
	}
}
