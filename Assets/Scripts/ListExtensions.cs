using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameFoundations
{
	public static class ListExtensions
	{

		private static System.Random rng = new System.Random ();  
		/// <summary>
		/// Shuffle the specified list in a pseudo random manner.
		/// </summary>
		/// <param name="list">List.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void Shuffle<T> (this IList<T> list)
		{  
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next (n + 1);  
				T value = list [k];  
				list [k] = list [n];  
				list [n] = value;  
			}  
		}
	
		public static T RandomItem<T> (this IList<T> list)
		{
			if (list.Count == 0)
				throw new System.IndexOutOfRangeException ("List is empty");
			return list [UnityEngine.Random.Range (0, list.Count)];
		}

		public static T[] RemoveRange<T> (this T[] array, int index, int count)
		{
			if (count < 0)
				throw new ArgumentOutOfRangeException ("count", " is out of range");
			if (index < 0 || index > array.Length - 1)
				throw new ArgumentOutOfRangeException ("index", " is out of range");
			
			if (array.Length - count - index < 0)
				throw new ArgumentException ("index and count do not denote a valid range of elements in the array", "");
			
			var newArray = new T[array.Length - count];
			
			for (int i = 0, ni = 0; i < array.Length; i++) {
				if (i < index || i >= index + count) {
					newArray [ni++] = array [i];
				}
			}
			
			return newArray;
		}
	}
}
