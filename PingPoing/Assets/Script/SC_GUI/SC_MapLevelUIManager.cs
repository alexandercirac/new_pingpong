/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using System.Collections.Generic;
using PingPong.CustomScriptableObject;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Local namespace
namespace PingPong.GUI.GameController
{

    /// <summary>
    /// 
    /// </summary>
    public class SC_MapLevelUIManager : MonoBehaviour
    {

        #region Public Variables
        /// <summary>
        /// 
        /// </summary>
        [System.Serializable]
        public class LevelMaps
        {
            public string id;
            public SC_LevelMapEditorScriptable levelMapEditorScriptable;
            public Image spriteLevel;
            public Button buttonLevel;
            public Text textLevel;
            public bool isUnlock;
        }
        /// <summary>
        ///  
        /// </summary>
        [HideInInspector]
        public List<LevelMaps> allLevels; 
        #endregion


        #region Private Variables
        #endregion


        #region Main Methods
        private void Start() => LoadStart();

        #endregion


        #region Utility Methods

        /// <summary>
        /// 
        /// </summary>
        private void LoadStart()
        {

            //allLevels.ForEach(x => x.buttonLevel.onClick.AddListener(() => LoadScene(x.levelMapEditorScriptable.sceneName)));

            //allLevels.ForEach(x => x.textLevel.text = x.levelMapEditorScriptable.displayName);

            //allLevels.ForEach(x => x.isUnlock = PlayerPrefs.GetInt(x.levelMapEditorScriptable.sceneName) == 1 ? true : false );

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameScen"></param>
        private void LoadScene(string nameScen)
        {

            SceneManager.LoadScene(nameScen);

        }
        #endregion


        #region Utility Events
        #endregion

    }
}
