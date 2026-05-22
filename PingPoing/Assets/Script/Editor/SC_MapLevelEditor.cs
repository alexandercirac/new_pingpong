/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using PingPong.Editors.Helper;
using PingPong.GUI.GameController;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CustomEditor(typeof(SC_MapLevelUIManager))]
public  class SC_MapLevelEditor : Editor
{

    #region Private Variables
    /// <summary>
    /// Aqui es donde objetendra la lista con sus elementos
    /// </summary>
    private SerializedProperty allLevels;
    /// <summary>
    /// Esto es para crear una lista reordenable
    /// </summary>
    private ReorderableList levelsList;
    #endregion


    #region Main Methods
    private void OnEnable()
    {
        allLevels = serializedObject.FindProperty("allLevels");

        levelsList = new ReorderableList(serializedObject , allLevels , true , true , true , true);

        CreateReorderableList(levelsList);
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        SC_ButtonsScriptEditorHelper.DrawScriptBox("SC_MapLevelUIManager" , "SC_MapLevelEditor");

        levelsList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }


    #endregion


    #region Utility Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelsList"></param>
    private void CreateReorderableList(ReorderableList levelsList)
    {
        //Esto  para que se dibuje la lista
        levelsList.drawHeaderCallback = rect =>
        {
            EditorGUI.LabelField(rect , "Map Levels");
        };

        // Esto es para que se reposicione al abrir y cerar la lista y que se reposicion segun la cantida de elmentos de la lista 
        levelsList.elementHeightCallback = index =>
        {
            SerializedProperty element = allLevels.GetArrayElementAtIndex(index);

            float line = EditorGUIUtility.singleLineHeight;
            float space = 4f;

            if (element.isExpanded)
            {
                // Foldout + 6 campos
                return (line + space) * 7f;
            }

            return line + space;
        };

        //Contenido de como se visualizara la lista
        levelsList.drawElementCallback = (rect , index , isActive , isFocused) =>
        {
            SerializedProperty element = allLevels.GetArrayElementAtIndex(index);

            SerializedProperty idLevel = element.FindPropertyRelative("id");
            SerializedProperty levelScriptable = element.FindPropertyRelative("levelMapEditorScriptable");
            SerializedProperty imageLevel = element.FindPropertyRelative("spriteLevel");
            SerializedProperty buttonLevel = element.FindPropertyRelative("buttonLevel");
            SerializedProperty textLevel = element.FindPropertyRelative("textLevel");
            SerializedProperty isUnlock = element.FindPropertyRelative("isUnlock");

            float line = EditorGUIUtility.singleLineHeight;
            float space = 2f;
            float y = rect.y + 2f;

            string title = string.IsNullOrEmpty(idLevel.stringValue)
                ? $"Level {index}"
                : idLevel.stringValue;

            element.isExpanded = EditorGUI.Foldout(
                new Rect(rect.x , y , rect.width , line) ,
                element.isExpanded ,
                title ,
                true
            );

            if (element.isExpanded)
            {
                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , idLevel);

                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , levelScriptable);

                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , imageLevel);

                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , buttonLevel);

                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , textLevel);

                y += line + space;
                EditorGUI.PropertyField(new Rect(rect.x , y , rect.width , line) , isUnlock);
            }
        };
    }
    #endregion


    #region Utility Events
    #endregion
}
