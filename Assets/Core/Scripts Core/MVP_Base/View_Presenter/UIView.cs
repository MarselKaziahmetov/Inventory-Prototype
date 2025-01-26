using Core.MVP;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.MVP
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView : MonoBehaviour, IUIView
    {
        private CanvasGroup _canvasGroup;

        private float _fadeDuration;
        private float _scalingDuration;

        private Tween _fadeInTween;
        private Tween _fadeOutTween;
        private Tween _increaseScaleTween;
        private Tween _decreaseScaleTween;

        [Inject]
        private void Init(UIParametrsSettings UIParametrs)
        {
            _fadeDuration = UIParametrs.FadeDuration;
            _scalingDuration = UIParametrs.ScalingDuration;
        }

        public bool IsVisible { get; private set; } = false;

        protected virtual void Awake()
        {
            _canvasGroup ??= GetComponent<CanvasGroup>();
            InitView();
            HashTweens();
        }


        public void InitView()
        {
            transform.localPosition = Vector3.zero;
            IsVisible = false;
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        public void Show_ViewInstantly()
        {
            IsVisible = true;

            _canvasGroup.alpha = 1f;

            AfterShow();
        }
        public void Hide_ViewInstantly()
        {
            IsVisible = false;

            _canvasGroup.alpha = 0f;

            AfterHide();
        }
        public void Show_ViewFading()
        {
            IsVisible = true;

            _fadeInTween.Play();

            AfterShow();
        }
        public void Hide_ViewFading()
        {
            IsVisible = false;

            _fadeOutTween.Play();

            AfterHide();
        }
        public void Show_ViewScaling()
        {
            IsVisible = true;

            _increaseScaleTween.Play();

            AfterShow();
        }
        public void Hide_ViewScaling()
        {
            IsVisible = false;

            _decreaseScaleTween.Play();

            AfterHide();
        }
        public void Show_ElementView(GameObject gameObject)
        {
            IsVisible = true;

            StartCoroutine(ShowElementAnimation(gameObject));

            AfterShow();
        }
        public void Hide_ElementView(GameObject gameObject)
        {
            IsVisible = false;

            StartCoroutine(HideElementAnimation(gameObject));

            AfterHide();
        }


        protected virtual void AfterHide()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        protected virtual void AfterShow()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }


        private void HashTweens()
        {
            _fadeInTween = _canvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.OutSine).SetAutoKill(false);
            _fadeOutTween = _canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.InSine).SetAutoKill(false);
            _increaseScaleTween = _canvasGroup.transform.DOScale(1f, _scalingDuration).SetEase(Ease.OutBack).SetAutoKill(false);
            _decreaseScaleTween = _canvasGroup.transform.DOScale(0f, _scalingDuration).SetEase(Ease.InBack).SetAutoKill(false);
        }
        private IEnumerator ShowElementAnimation(GameObject gameObject)
        {
            _fadeInTween.Play();
            yield return new WaitForSeconds(_fadeDuration);
            gameObject.transform.DOScale(1f, _scalingDuration).SetEase(Ease.OutBack);
        }
        private IEnumerator HideElementAnimation(GameObject gameObject)
        {
            gameObject.transform.DOScale(0f, _scalingDuration).SetEase(Ease.InBack);
            yield return new WaitForSeconds(_scalingDuration);
            _fadeOutTween.Play();
        }
    }
}
