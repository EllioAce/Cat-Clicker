using Godot;
using System;

public static class Utils
{
    public static T GetFirstChildOfType<T>(Node node)
    {
        foreach (Node child in node.GetChildren())
        {
            if (child is T typeChild) return typeChild;
        }
        throw new NullReferenceException($"Child of type {typeof(T)} in node {node.Name} does not exist");
    }
}
