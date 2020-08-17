using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollectItem))]
[System.Serializable]
public class CollectItemEditor : Editor
{
    bool ShowBaseElements;

    //[SerializeField]
    //CollectItem Item;
    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        ShowBaseElements = EditorGUILayout.Toggle(new GUIContent("Show Raw Elements", "Shows ALL the variables mostly a debug check"), ShowBaseElements);
        if (ShowBaseElements) base.OnInspectorGUI();

     

        GUILayout.Label("----CUSTOM EDITOR----", EditorStyles.boldLabel);
        //serializedObject.FindProperty("MyType").enumValueIndex = EditorGUILayout.EnumPopup("Item Type",);

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("MyType"));
        CollectItem Item = (CollectItem)target;

        /*
        var offsetProperty = serializedObject.FindProperty("Offset");
        EditorGUILayout.PropertyField(offsetProperty);
        serializedObject.ApplyModifiedProperties();
        */

        var ObjectField = serializedObject.FindProperty("MyType");
        EditorGUILayout.PropertyField(ObjectField);


        switch (Item.MyType)
        {
            case CollectibleType.KEYS:
                #region
                GUILayout.Label("----KEYS EDITOR----", EditorStyles.boldLabel);
                    ObjectField = serializedObject.FindProperty("Portal");
                    EditorGUILayout.PropertyField(ObjectField);
                #endregion
                break;
            
            case CollectibleType.POWERUP:
                #region
                GUILayout.Label("----POWERUPS EDITOR----", EditorStyles.boldLabel);
                    GUILayout.Label("This is uhhh... Being worked on", EditorStyles.label);
                #endregion
                break;
            case CollectibleType.SHOTOVERRIDE:
            case CollectibleType.TEMPSHOT:
                GUILayout.Label("----SHOT OVERRIDE EDITOR----", EditorStyles.boldLabel);
                ObjectField = serializedObject.FindProperty("AbilitySlot");
                EditorGUILayout.PropertyField(ObjectField);
                ObjectField = serializedObject.FindProperty("MyAbility");
                EditorGUILayout.PropertyField(ObjectField);
                ObjectField = serializedObject.FindProperty("ShotCount");
                EditorGUILayout.PropertyField(ObjectField);
                break;
            default:
                break;
        }



        serializedObject.ApplyModifiedProperties();
    }

    

}
