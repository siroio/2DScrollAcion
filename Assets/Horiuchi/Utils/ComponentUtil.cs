using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentUtil
{
    public static T TryGetComponent<T>(T cmp) where T : Component
    {
        if (cmp.TryGetComponent<T>(out var component) == false)
        {
            throw new NotAttachException<T>();
        }
        return component;
    }

    public static T GetComponentInChildren<T>(Component self) where T : Component
    {
        foreach (var child in self.GetComponentsInChildren<T>())
        {
            if (child.gameObject == self.gameObject) continue;
            return child;
        }
        return null;
    }
}
