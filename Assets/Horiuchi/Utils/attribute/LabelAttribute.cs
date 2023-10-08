using UnityEngine;
using UnityEditor;

public class LabelAttribute : PropertyAttribute
{
    public readonly string CustomLabel;

    public LabelAttribute(string CustomLabel) => this.CustomLabel = CustomLabel;
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(LabelAttribute))]
public class LabelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, new GUIContent((attribute as LabelAttribute)?.CustomLabel), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, true);
    }
}

#endif
