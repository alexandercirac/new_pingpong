/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using FMOD.Studio;
using PingPong.CustomScriptableObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Local namespace
namespace PingPong.GUI.GameController
{

    public class SC_SoundController : MonoBehaviour
    {
        #region Public Variables
        #endregion


        #region Private Variables
        [FMODUnity.BankRef]
        [SerializeField] private string[] banks;
        #endregion


        #region Main Methods
        private void Awake() => LoadSoundAwake();

        #endregion


        #region Utility Methods

        /// <summary>
        /// 
        /// </summary>
        private void LoadSoundAwake()
        {
            if (banks.Any(x =>  string.IsNullOrEmpty(x)))           
                return;

            foreach (var item in banks)
            {                
                FMODUnity.RuntimeManager.LoadBank(item, false);
            }
        }

        #endregion


        #region Utility Events
        #endregion

    }
}
