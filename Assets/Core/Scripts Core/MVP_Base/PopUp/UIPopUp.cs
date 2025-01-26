using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.MVP
{
    [RequireComponent(typeof(CanvasGroup))]
	public abstract class UIPopUp : MonoBehaviour, IUIPopUp
	{
		private CanvasGroup _canvasGroup;

        private float _fadeDuration;
        private float _scalingDuration;
        private float _dropSpeed;

        public event Action Hided;
        public event Action Showed;

        public bool IsVisible{ get; private set; } = false;


        [Inject]
        private void Init(UIParametrsSettings UIParametrs)
        {
            _fadeDuration = UIParametrs.FadeDuration;
            _scalingDuration = UIParametrs.ScalingDuration;
            _dropSpeed = UIParametrs.DropSpeed;
        }

		protected virtual void Awake()
		{
			_canvasGroup ??= GetComponent<CanvasGroup>();
            InitHidedPopUp();
        }


        public void InitHidedPopUp()
        {
            transform.localPosition = Vector3.zero;
            IsVisible = false;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        } 
        public void InitShowedPopUp()
        {
            transform.localPosition = Vector3.zero;
            IsVisible = true;
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void Show(bool isInteractable = true, bool isBlocksRaycasts = true)
        {
            AfterShow();
        }
        public void Hide(bool isInteractable = false, bool isBlocksRaycasts = false)
        {
            AfterHide();
        }
        public void Show_PopUpFading()
        {
            _canvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.OutSine);

            AfterShow(_fadeDuration);
        }
        public void Hide_PopUpFading()
        {
            _canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.InSine);

            AfterHide(_fadeDuration);
        }
        public void Show_PopUpScaling()
        {
            _canvasGroup.transform.DOScale(1f, _scalingDuration).SetEase(Ease.OutBack);

            AfterShow(_scalingDuration);
        }
        public void Hide_PopUpScaling()
        {
            _canvasGroup.transform.DOScale(0f, _scalingDuration).SetEase(Ease.InBack);

            AfterHide(_scalingDuration);
        }
        public void Show_ElementScaling_ViewFading(GameObject element)
        {
            StartCoroutine(ShowElementAnimation(element));
        }
        public void Hide_ElementScaling_ViewFading(GameObject element)
        {
            StartCoroutine(HideElementAnimation(element));
        }
        public void Show_DropOutFadeOut()
        {
            _canvasGroup.transform.position = new Vector3(_canvasGroup.transform.position.x, Screen.height, _canvasGroup.transform.position.z);
            
            _canvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.InSine);
            _canvasGroup.transform.DOMoveY(Screen.height/2, _dropSpeed).SetEase(Ease.OutSine);

            AfterShow(_fadeDuration);
        }
        public void Hide_DropOutFadeOut()
        {
            _canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.OutSine);
            _canvasGroup.transform.DOMoveY(-Screen.height, _dropSpeed).SetEase(Ease.InSine);

            AfterHide(_fadeDuration);
        }


        protected virtual void AfterHide(float delay = 0)
		{
            _canvasGroup.interactable = false;
            StartCoroutine(DelayedHide(delay));
        }
		protected virtual void AfterShow(float delay = 0)
		{
            StartCoroutine(DelayedShow(delay));
        }


        private IEnumerator ShowElementAnimation(GameObject element)
        {
            _canvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.OutSine);
            yield return new WaitForSeconds(_fadeDuration);
            element.transform.DOScale(1f, _scalingDuration).SetEase(Ease.OutBack);
            AfterShow(_scalingDuration);
        }
        private IEnumerator HideElementAnimation(GameObject element)
        {
            element.transform.DOScale(0f, _scalingDuration).SetEase(Ease.InBack);
            yield return new WaitForSeconds(_scalingDuration);
            _canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.InSine);
            AfterHide(_fadeDuration);
        }

        private IEnumerator DelayedShow(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            IsVisible = true;
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            
            Showed?.Invoke();
        }
        private IEnumerator DelayedHide(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            IsVisible = false;
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;

            Hided?.Invoke();
        }
    }
}
