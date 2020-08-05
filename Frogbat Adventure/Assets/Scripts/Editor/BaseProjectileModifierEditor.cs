using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseProjectileModifier))]
[System.Serializable]
public class BaseProjectileModifierEditor : Editor
{

    bool ShowBaseElements;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ShowBaseElements = EditorGUILayout.Toggle(new GUIContent("Show Raw Elements", "Shows ALL the variables mostly a debug check"), ShowBaseElements);
        if (ShowBaseElements) base.OnInspectorGUI();

        BaseProjectileModifier Modifier = (BaseProjectileModifier) target;


        SerializedProperty ObjectField = null;

        RenderParameter(ObjectField, "ModifierProperties");

        ProjectileModifier Mod = Modifier.ModifierProperties;

        //foreach (ProjectileModifier Mod in Modifier.ModifierProperties)
        //{
            switch (Mod)
            {
                case ProjectileModifier.None:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() + " ----", EditorStyles.boldLabel);
                    break;
                case ProjectileModifier.Piercing:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() +"----", EditorStyles.boldLabel);
                    RenderParameter(ObjectField, "CollisionLayers");
                    break;
                case ProjectileModifier.Multipart:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() + "----", EditorStyles.boldLabel);
                    RenderParameter(ObjectField, "NextProjectiles");
                    break;
                case ProjectileModifier.Bouncing:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() + "----", EditorStyles.boldLabel);
                    RenderParameter(ObjectField, "BounceAngle");
                    break;
                case ProjectileModifier.Stats:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() + "----", EditorStyles.boldLabel);
                    RenderParameter(ObjectField, "ModSpeed");
                    RenderParameter(ObjectField, "ModDistance");
                    RenderParameter(ObjectField, "ModLifespan");
                    break;
                default:
                    GUILayout.Label("----PAREMETERS " + Mod.ToString() +" DOES NOT EXIST----", EditorStyles.boldLabel);
                    break;
            }
        //}

        serializedObject.ApplyModifiedProperties();
    }

    void RenderParameter(SerializedProperty _ObjectField, string parameter)
    {
        _ObjectField = serializedObject.FindProperty(parameter);
        EditorGUILayout.PropertyField(_ObjectField);
    }
    void RenderParameter(SerializedProperty _ObjectField, string parameter, string description)
    {
        _ObjectField = serializedObject.FindProperty(parameter);
        EditorGUILayout.PropertyField(_ObjectField, new GUIContent(description));
    }
}
