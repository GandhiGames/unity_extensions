using UnityEngine;
using System.Collections;

namespace GameFoundations
{
	public static class ColourExtensions
	{
		public static Color WithAlpha (this Color color, float alpha)
		{
			return new Color (color.r, color.g, color.b, alpha);
		}

	}
}
