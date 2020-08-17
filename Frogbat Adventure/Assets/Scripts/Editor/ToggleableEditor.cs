using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Toggleable))]
[System.Serializable]
public class ToggleableEditor : Editor
{
    bool ShowBaseElements;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ShowBaseElements = EditorGUILayout.Toggle(new GUIContent("Show Raw Elements", "Shows ALL the variables mostly a debug check"), ShowBaseElements);
        if (ShowBaseElements) base.OnInspectorGUI();

        GUILayout.Label("----CUSTOM EDITOR----", EditorStyles.boldLabel);

        Toggleable Item = (Toggleable)target;

        var ObjectField = serializedObject.FindProperty("Type");
        EditorGUILayout.PropertyField(ObjectField);

        switch (Item.Type)
        {
            case ToggleType.Effector:
                GUILayout.Label("----Effector Editor----", EditorStyles.boldLabel);
                ObjectField = serializedObject.FindProperty("ColliderHeight");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Height", "Tiles Tall"));
                ObjectField = serializedObject.FindProperty("Rate");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Rate", "How Fast it grows/Decays"));
                ObjectField = serializedObject.FindProperty("Collider");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Toggle Box", "What is toggled on or off"));
                ObjectField = serializedObject.FindProperty("Sprite");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Sprite", "The thing that represents the Area"));
                ObjectField = serializedObject.FindProperty("Delay");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Delay", "How fast between Updates the collider/sprite"));
                break;
            case ToggleType.GameObject:
                break;
            case ToggleType.Collider:
                ObjectField = serializedObject.FindProperty("Collider");
                EditorGUILayout.PropertyField(ObjectField, new GUIContent("Collider", "The thing to turn on or off"));
                
                break;
            case ToggleType.Animator:
            default:
                GUILayout.Label("----This don't exist----", EditorStyles.boldLabel);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
