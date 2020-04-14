using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtension
{
    /// <summary>
    /// Create a GameObject and set it as the children of the parent and return the GO
    /// </summary>
    /// <param name="Parent"></param>
    /// <returns></returns>
    public static GameObject CreateChildren(this GameObject Parent, string name)
    {
        GameObject go = new GameObject();
        go.transform.SetParent(Parent.transform);
        go.name = name;
        return go;
    }

    public static GameObject CreateChildren(this GameObject Parent)
    {
        return Parent.CreateChildren(Parent.name + " Child");
    }
}
