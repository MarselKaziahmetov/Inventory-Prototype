using Core.MVP;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Core.Modules.SceneSwitcher
{
    public class SceneSwitcherView : UIPopUp
    {
        #region Variables
        [Header("Animation Elements")]
        [SerializeField] private CanvasGroup _fadeImage;

        [Header("Settings")]
        [SerializeField] private float _fadeAnimDuration;

        public event Action<string> Switch;
        public event Action OnFadeIn;
        public event Action OnFadeOut;
        #endregion


        #region Unity lifecycle
        private void Start()
        {
            InitElementsVisibility();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Switch?.Invoke("SwitchingTestScene");
            }
        }
        #endregion


        #region Public methods
        internal void FadeInView()
        {
            StartCoroutine(DelayedFadeIn(_fadeAnimDuration));
        }
        internal void FadeOutView()
        {
            StartCoroutine(DelayedFadeOut(_fadeAnimDuration));
        }
        #endregion


        #region Private methods
        private void InitElementsVisibility()
        {
            _fadeImage.alpha = 0;
        }
        private IEnumerator DelayedFadeIn(float delay)
        {
            Show();
            _fadeImage.DOFade(1, delay).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(delay);
            OnFadeIn?.Invoke();
        }
        private IEnumerator DelayedFadeOut(float delay)
        {
            _fadeImage.DOFade(0, delay).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(delay);
            Hide();
            OnFadeOut?.Invoke();
        }
        #endregion
    }
}
