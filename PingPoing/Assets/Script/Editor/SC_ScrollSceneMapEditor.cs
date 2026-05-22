/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using PingPong.GUI.GameController.Scene;
using PingPong.Editors.Helper;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CustomEditor(typeof(SC_ScrollSceneMapManager))]

public class  SC_ScrollSceneMapEditor : Editor
{

    #region Private Variables
    /// <summary>
    /// 
    /// </summary>
    private SerializedProperty _scrollbar;
    /// <summary>
    /// 
    /// </summary>
    private SerializedProperty _mapLevel;
    /// <summary>
    /// 
    /// </summary>
    private SerializedProperty _trackChangeLevel;
    /// <summary>
    /// 
    /// </summary>
    private SerializedProperty _scrollContent;

    #endregion


    #region Main Methods
    private void OnEnable()
    {
        _scrollbar = serializedObject.FindProperty("scrollbar");
        _mapLevel = serializedObject.FindProperty("mapLevel");
        _trackChangeLevel = serializedObject.FindProperty("_trackChangeLevel");
        _scrollContent = serializedObject.FindProperty("_scrollContent");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SC_ButtonsScriptEditorHelper.DrawScriptBox("SC_ScrollSceneMapManager", "SC_ScrollSceneMapEditor");

        EditorGUILayout.Space(1);
        VisualizeVariables();

        serializedObject.ApplyModifiedProperties();
    }
    #endregion


    #region Utility Methods  

    /// <summary>
    /// 
    /// </summary>
    private void VisualizeVariables()
    {
        EditorGUILayout.PropertyField(_scrollbar, new GUIContent("Content Scene Map"));
        EditorGUILayout.PropertyField(_mapLevel, new GUIContent("Map Level Manager"));
        EditorGUILayout.PropertyField(_trackChangeLevel , new GUIContent("Track Change Level"));
        EditorGUILayout.PropertyField(_scrollContent , new GUIContent("Scroll Content"));
    }
    #endregion


    #region Utility Events
    #endregion

}
