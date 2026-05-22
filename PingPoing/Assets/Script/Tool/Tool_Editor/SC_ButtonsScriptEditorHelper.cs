/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

namespace PingPong.Editors.Helper
{

    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public static class SC_ButtonsScriptEditorHelper
    {

        #region Private Variables
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, MonoScript> cache = new();
        #endregion


        #region Main Methods
        #endregion


        #region Utility Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptNames"></param>
        public static void DrawScriptBox(params string[] scriptNames)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            foreach (string scriptName in scriptNames)
            {
                MonoScript script = GetScript(scriptName);

                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(scriptName, GUILayout.MinWidth(160));

                GUI.enabled = script != null;

                if (GUILayout.Button("Abrir"))
                {
                    AssetDatabase.OpenAsset(script);
                }

                if (GUILayout.Button("Localizar"))
                {
                    EditorGUIUtility.PingObject(script);
                }

                GUI.enabled = true;

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        private static MonoScript GetScript(string scriptName)
        {
            if (cache.TryGetValue(scriptName, out MonoScript script))
                return script;

            script = FindScriptByName(scriptName);
            cache[scriptName] = script;

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        private static MonoScript FindScriptByName(string scriptName)
        {
            string[] guids = AssetDatabase.FindAssets($"{scriptName} t:MonoScript");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

                if (script != null && script.name == scriptName)
                    return script;
            }

            return null;
        }
        #endregion


        #region Utility Events
        #endregion

    }
}
