/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using UnityEngine;

//Local namespace
namespace PingPong.CustomScriptableObject
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfig" , menuName = "Levels/Level Config")]
    public class SC_LevelMapEditorScriptable : ScriptableObject
    {

        #region Public Variables
        /// <summary>
        /// 
        /// </summary>
        public string id;           // único: "L1", "L2", etc.

        /// <summary>
        /// 
        /// </summary>
        public string displayName;  // para UI

        /// <summary>
        /// 
        /// </summary>
        public string sceneName;    // nombre de la escena en Build Settings

        /// <summary>
        /// 
        /// </summary>
        public Sprite imageLock; // imagen que se resalte cuando este bloqueado

        /// <summary>
        /// 
        /// </summary>
        public Sprite imageUnlock; // imagen que se resalte cuando este debloqueado
        #endregion


        #region Private Variables

        #endregion


        #region Main Methods
        #endregion


        #region Utility Methods
        #endregion


        #region Utility Events
        #endregion
    }
}
