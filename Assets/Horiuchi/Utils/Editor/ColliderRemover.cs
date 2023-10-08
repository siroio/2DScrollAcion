using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : Editor
{

    [MenuItem("Tools/SUnity Tools/Selected Object Collider Remover", priority = 100)]
    private static void Create()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            foreach (var col in go.GetComponentsInChildren<Collider>())
            {
                DestroyImmediate(col);
            }
        }
    }
}
