/// INFORMATION
/// 
/// Project: PingPong
/// Game: PingPong "New Futre"
/// Date: 12/04/2025
/// Programmers: Alexander Cirac Antio
/// Description: 

using DG.Tweening;
using UniRx;
using UnityEngine;

//Local namespace
namespace PingPong.GUI.GameController.Scene
{
    using FMOD.Studio;
    using FMODUnity;
    using UnityEngine.InputSystem;
    using UnityEngine.UI;

    /// <summary>
    /// 
    /// </summary>
    public class SC_ScrollSceneMapManager : MonoBehaviour
    {

        #region Public Variables
        /// <summary>
        /// 
        /// </summary>
        public SC_MapLevelUIManager mapLevel;
        /// <summary>
        /// 
        /// </summary>
        public Scrollbar scrollbar;
        /// <summary>
        /// 
        /// </summary>
        public FMODUnity.EventReference _trackChangeLevel;
        /// <summary>
        /// 
        /// </summary>
        public GameObject _scrollContent;
        #endregion


        #region Private Variables
        /// <summary>
        /// 
        /// </summary>
        private float distance;        
        /// <summary>
        /// 
        /// </summary>
        private float[] pos;
        /// <summary>
        /// 
        /// </summary>
        private int currentSelectedIndex = -1;
        /// <summary>
        /// 
        /// </summary>
        private int lastSelectedIndex = -1;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private float scaleDuration = 0.35f;
        #endregion


        #region Unity Calls
        void Awake() => GetSave();
        void Start() => Init();
        #endregion


        #region Utility Methods
        /// <summary>
        /// 
        /// </summary>
        private void GetSave()
        {
            PlayerPrefs.SetInt("Intro", 1);
            PlayerPrefs.Save();


        }
        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {

            DOTween.Init();
            GetAllPositionElements();
            InitAnimatesButtons();
            scrollbar.OnValueChangedAsObservable()
                     .Subscribe(x => OnScrollValueChanged(x))
                     .AddTo(this);
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetAllPositionElements()
        {
            int childCount = _scrollContent.transform.childCount;
            pos = new float[childCount];
            distance = 1f / (childCount - 1f);

            for (int i = 0 ; i < childCount ; i++)
            {
                pos[i] = distance * i;
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="scrollValue"></param>
        private void OnScrollValueChanged(float scrollValue)
        {
           int nearestIndex = GetCurrentIndex(scrollValue);
           bool isSameOrInvalidIndex = nearestIndex == -1 || nearestIndex == currentSelectedIndex;
           bool isLastIndexNegative = lastSelectedIndex != -1;
           float selectedSacale = 1f;
           float normalScale = 0.8f;

            lastSelectedIndex = currentSelectedIndex;

           if (isSameOrInvalidIndex)
               return;

            currentSelectedIndex = nearestIndex;


            AnimateButton(currentSelectedIndex, selectedSacale, true);
            if(isLastIndexNegative)
            AnimateButton(lastSelectedIndex, normalScale, false);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrollValue"></param>
        /// <returns></returns>
        private int GetCurrentIndex(float scrollValue)
        {
            int nearestIndex = -1;
            float minDistance = float.MaxValue;

            for (int i = 0 ; i < pos.Length ; i++)
            {
                float currentDistance = Mathf.Abs(scrollValue - pos[i]);

                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    nearestIndex = i;
                }
            }

            return nearestIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void InitAnimatesButtons()
        {
            for (int i = 0 ; i < pos.Length ; i++)
            {
                Transform child = _scrollContent.transform.GetChild(i);
                float selectedSacale = 1f;
                float normalScale = 0.8f;
                float targetScale = i == 0 ? selectedSacale : normalScale;

                child.DOKill();

                child.DOScale(targetScale , scaleDuration)
                     .SetEase(Ease.Flash);

                Button button = child.GetComponent<Button>();

                button.interactable = i == 0
                    ? mapLevel.allLevels[i].isUnlock
                    : false;

                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <param name="targetScale"></param>
        /// <param name="isInteractable"></param>
        private void AnimateButton(int selectedIndex , float targetScale , bool isInteractable)
        {
            Transform child = _scrollContent.transform.GetChild(selectedIndex);

            child.DOKill();

            child.DOScale(targetScale, scaleDuration)
                 .SetEase(Ease.OutElastic);

            Button button = child.GetComponent<Button>();

            button.interactable = isInteractable
                ? mapLevel.allLevels[selectedIndex].isUnlock
                : false;

            
            FMODUnity.RuntimeManager.PlayOneShot(_trackChangeLevel);

        }
        #endregion

    }
}
