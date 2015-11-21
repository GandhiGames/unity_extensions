using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameFoundations
{
	public static class GameObjectExtensions
	{
		public static void SetLayerRecursively (this GameObject gameObject, int layer)
		{
			gameObject.layer = layer;

			foreach (Transform t in gameObject.transform) {
				t.gameObject.SetLayerRecursively (layer);
			}
		}

		public static void SetCollisionRecursively (this GameObject gameObject, bool enabled)
		{
			Collider[] colliders = gameObject.GetComponentsInChildren<Collider> ();

			foreach (Collider collider in colliders) {
				collider.enabled = enabled;
			}
		}

		public static void SetRendererRecursively (this GameObject gameObject, bool enabled)
		{
			Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();

			foreach (Renderer renderer in renderers) {
				renderer.enabled = enabled;
			}
		}

		public static T[] GetComponentsInChildrenWithTag<T> (this GameObject gameObject, string tag) where T: Component
		{
			var results = new List<T> ();
			
			if (gameObject.CompareTag (tag)) {
				results.Add (gameObject.GetComponent<T> ());
			}
			
			foreach (Transform t in gameObject.transform) {
				results.AddRange (t.gameObject.GetComponentsInChildrenWithTag<T> (tag));
			}
			
			return results.ToArray ();
		}

		public static T GetComponentInParents<T> (this GameObject gameObject) where T : Component
		{
			for (Transform t = gameObject.transform; t != null; t = t.parent) {
				T result = t.GetComponent<T> ();

				if (result != null) {
					return result;
				}
			}
			
			return null;
		}

		public static T[] GetComponentsInParents<T> (this GameObject gameObject) where T: Component
		{
			var results = new List<T> ();
			for (Transform t = gameObject.transform; t != null; t = t.parent) {
				T result = t.GetComponent<T> ();

				if (result != null) {
					results.Add (result);
				}
			}
			
			return results.ToArray ();
		}

		/// <summary>
		/// Gets the the set of layers that object can collide with.
		/// </summary>
		/// <returns>The collision mask.</returns>
		/// <param name="gameObject">Game object.</param>
		/// <param name="layer">Layer.</param>
		public static int GetCollisionMask (this GameObject gameObject, int layer = -1)
		{
			if (layer == -1) {
				layer = gameObject.layer;
			}
			
			int mask = 0;

			for (int i = 0; i < 32; i++) {
				mask |= (Physics.GetIgnoreLayerCollision (layer, i) ? 0 : 1) << i;
			}
			
			return mask;
		}

		public static bool IsInLayerMask (this GameObject gameObject, LayerMask mask)
		{
			return ((mask.value & (1 << gameObject.layer)) > 0);
		}

		public static T GetInterface<T> (this GameObject inObj) where T : class
		{
			if (!typeof(T).IsInterface) {
				Debug.LogError (typeof(T).ToString () + ": is not an actual interface");
				return null;
			}
			
			return inObj.GetComponents<Component> ().OfType<T> ().FirstOrDefault ();
		}
		
		public static IEnumerable<T> GetInterfaces<T> (this GameObject inObj) where T : class
		{
			if (!typeof(T).IsInterface) {
				Debug.LogError (typeof(T).ToString () + ": is not an actual interface");
				return Enumerable.Empty<T> ();
			}
			
			return inObj.GetComponents<Component> ().OfType<T> ();
		}

	}
}
