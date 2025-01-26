using UnityEngine;
using System;

namespace Core.MVP
{
	public interface IUIPopUp
	{
        event Action Hided;
        event Action Showed;


        /// <summary>
        /// Вызывается в методе Start для инициализации PopUP(Центрировать и скрыть)
        /// Все наследники от абстрактного класса, который реализует интерфейс IUIPopUp,
        /// обязаны в методы старт реализовать базовый метод base.Awake();
        /// </summary>
        void InitHidedPopUp();
        /// <summary>
        /// Вызывается в методе Start для инициализации PopUP(Центрировать и показать)
        /// Все наследники от абстрактного класса, который реализует интерфейс IUIPopUp,
        /// обязаны в методы старт реализовать базовый метод base.Awake();
        /// </summary>
        void InitShowedPopUp();


        /// <summary>
        /// Скрывает PopUp модуля без анимации, с дополнительными настройками
        /// </summary>
        /// <param name="isInteractable"></param>
        /// <param name="isBlocksRaycasts"></param>
        void Show(bool isInteractable, bool isBlocksRaycasts);
        /// <summary>
        /// Раскрывает PopUp модуля без анимации, с дополнительными настройками
        /// </summary>
        /// <param name="isInteractable"></param>
        /// <param name="isBlocksRaycasts"></param>
        void Hide(bool isInteractable, bool isBlocksRaycasts);

        /// <summary>
        /// Скрывает PopUp модуля через анимацию FadeOut 
        /// </summary>
        void Hide_PopUpFading();
        /// <summary>
        /// Раскрывает PopUp модуля через анимацию FadeIn
        /// </summary>
        void Show_PopUpFading();
        
        /// <summary>
        /// Скрывает PopUp модуля через анимацию Scaling
        /// </summary>
        void Hide_PopUpScaling();
        /// <summary>
        /// Раскрывает PopUp модуля через анимацию Scaling
        /// </summary>
        void Show_PopUpScaling();

        /// <summary>
        /// Скрывает сначала UI элемент модуля через анимацию Scaling, а затем PopUp модуля через анимацию FadeOut
        /// </summary>
        /// <param name="canvas">UI элемент для скалирования</param>
        void Hide_ElementScaling_ViewFading(GameObject element);
        /// <summary>
        /// Раскрывает сначала UI элемент модуля через анимацию Scaling, а затем PopUp модуля через анимацию FadeIn
        /// </summary>
        /// <param name="canvas">UI элемент для скалирования</param>
        void Show_ElementScaling_ViewFading(GameObject element);

        /// <summary>
        /// Скрывает PopUp модуля через анимацию перемещения вниз и FadeOut
        /// </summary>
        void Hide_DropOutFadeOut();
        /// <summary>
        /// Раскрывает PopUp модуля через анимацию перемещения вниз и FadeIn
        /// </summary>
        void Show_DropOutFadeOut();
    }
}