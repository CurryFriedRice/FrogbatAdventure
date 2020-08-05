using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseProjectile))]
[System.Serializable]
public class BaseProjectileEditor : Editor
{

    bool ShowBaseElements;
    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        ShowBaseElements = EditorGUILayout.Toggle(new GUIContent("Show Raw Elements", "Shows ALL the variables mostly a debug check"), ShowBaseElements);
        if (ShowBaseElements) base.OnInspectorGUI();



        GUILayout.Label("----Global Fields----", EditorStyles.boldLabel);
        BaseProjectile Bullet = (BaseProjectile)target;

        SerializedProperty ObjectField = null;
        
        RenderParameter(ObjectField, "FlightLogic");

  
        switch (Bullet.FlightLogic)
        {
            case ProjectileLogic.Basic:
                #region
                GUILayout.Label("----Basic Shot Parameters----", EditorStyles.boldLabel);
                RenderParameter(ObjectField, "Speed");
                RenderParameter(ObjectField, "Lifespan");
                RenderParameter(ObjectField, "Distance");
                

                #endregion
                break;

            case ProjectileLogic.Boomerang:
                #region
                GUILayout.Label("----Boomerang Shot Parameters----", EditorStyles.boldLabel);
                RenderParameter(ObjectField, "Speed");
                RenderParameter(ObjectField, "Lifespan");
                RenderParameter(ObjectField, "Distance", "Return Distance");
                

                #endregion
                break;
            case ProjectileLogic.Lift:
                GUILayout.Label("----Lift Shot Parameters----", EditorStyles.boldLabel);
                RenderParameter(ObjectField, "Speed");
                RenderParameter(ObjectField, "Lifespan");
                RenderParameter(ObjectField, "Distance", "Out Distance");
                RenderParameter(ObjectField, "UpDistance", "Up Distance");
                
           
                break;
            case ProjectileLogic.Lob:
                GUILayout.Label("----Lob Shot Parameters----", EditorStyles.boldLabel);
                RenderParameter(ObjectField, "Speed");
                RenderParameter(ObjectField, "Lifespan");
                RenderParameter(ObjectField, "Distance", "Out Distance");
                RenderParameter(ObjectField, "UpDistance", "Up Distance");
                
                break;
            default:
                break;
        }

        RenderParameter(ObjectField, "DestroyByDistance", "Destroyed by Distance");
        RenderParameter(ObjectField, "DestroyByLifespan", "Destroyed by Lifespan");

        serializedObject.ApplyModifiedProperties();
    }


    void RenderParameter(SerializedProperty _ObjectField, string parameter)
    {
        _ObjectField = serializedObject.FindProperty(parameter);
        EditorGUILayout.PropertyField(_ObjectField);
    }

    void RenderParameter(SerializedProperty _ObjectField,string parameter, string description)
    {
        _ObjectField = serializedObject.FindProperty(parameter);
        EditorGUILayout.PropertyField(_ObjectField, new GUIContent(description));
    }
}
