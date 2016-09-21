using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public static class GameObjectExtensions
{
    /// <summary>
    /// Sets layer on gameobject and any children objects.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="layer"></param>
    public static void SetLayerRecursively(this GameObject gameObject, int layer)
    {
        gameObject.layer = layer;

        foreach (Transform t in gameObject.transform)
        {
            t.gameObject.SetLayerRecursively(layer);
        }
    }

    /// <summary>
    /// Sets collision enabled on gameobject and any children object.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="enabled"></param>
    public static void SetCollisionRecursively(this GameObject gameObject, bool enabled)
    {
        var parentCollider = gameObject.GetComponent<Collider>();

        if (parentCollider)
        {
            parentCollider.enabled = enabled;
        }

        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = enabled;
        }
    }

    public static void SetRendererRecursively(this GameObject gameObject, bool enabled)
    {
        var parentRenderer = gameObject.GetComponent<Renderer>();

        if (parentRenderer)
        {
            parentRenderer.enabled = enabled;
        }

        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = enabled;
        }
    }

    /// <summary>
    /// Returns array of T components attached to gameobject with specified tag.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static T[] GetComponentsInChildrenWithTag<T>(this GameObject gameObject, string tag) where T : Component
    {
        var results = new List<T>();

        if (gameObject.CompareTag(tag))
        {
            results.Add(gameObject.GetComponent<T>());
        }

        foreach (Transform t in gameObject.transform)
        {
            results.AddRange(t.gameObject.GetComponentsInChildrenWithTag<T>(tag));
        }

        return results.ToArray();
    }


    /// <summary>
    /// Gets the the set of layers that object can collide with.
    /// </summary>
    /// <returns>The collision mask.</returns>
    /// <param name="gameObject">Game object.</param>
    /// <param name="layer">Layer.</param>
    public static int GetCollisionMask(this GameObject gameObject, int layer = -1)
    {
        if (layer == -1)
        {
            layer = gameObject.layer;
        }

        int mask = 0;

        for (int i = 0; i < 32; i++)
        {
            mask |= (Physics.GetIgnoreLayerCollision(layer, i) ? 0 : 1) << i;
        }

        return mask;
    }

    public static bool IsInLayerMask(this GameObject gameObject, LayerMask mask)
    {
        return ((mask.value & (1 << gameObject.layer)) > 0);
    }

    public static T GetInterface<T>(this GameObject inObj) where T : class
    {
        if (!typeof(T).IsInterface)
        {
            Debug.LogError(typeof(T).ToString() + ": is not an interface");
            return null;
        }

        return inObj.GetComponents<Component>().OfType<T>().FirstOrDefault();
    }

    public static IEnumerable<T> GetInterfaces<T>(this GameObject inObj) where T : class
    {
        if (!typeof(T).IsInterface)
        {
            Debug.LogError(typeof(T).ToString() + ": is not an interface");
            return Enumerable.Empty<T>();
        }

        return inObj.GetComponents<Component>().OfType<T>();
    }

}

