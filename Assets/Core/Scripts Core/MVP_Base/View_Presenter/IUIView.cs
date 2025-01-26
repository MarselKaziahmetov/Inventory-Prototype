namespace Core.MVP
{
    public interface IUIView
    {
        /// <summary>
        /// Вызывается в методе Start для инициализации View(Центрировать и скрыть)
        /// Все наследники от абстрактного класса, который реализует интерфейс IUIView,
        /// обязаны в методы старт реализовать базовый метод base.Start();
        /// </summary>
        void InitView();

        /// <summary>
        /// Мгновенно скрывает View модуля 
        /// </summary>
        void Hide_ViewInstantly();

        /// <summary>
        /// Мгновенно раскрывает View модуля 
        /// </summary>
        void Show_ViewInstantly();
        
        /// <summary>
        /// Скрывает View модуля через анимацию FadeOut 
        /// </summary>
        void Hide_ViewFading();
        
        /// <summary>
        /// Раскрывает View модуля через анимацию FadeIn
        /// </summary>
        void Show_ViewFading();
        
        /// <summary>
        /// Скрывает View модуля через анимацию Scaling
        /// </summary>
        void Hide_ViewScaling();
        
        /// <summary>
        /// Раскрывает View модуля через анимацию Scaling
        /// </summary>
        void Show_ViewScaling();
    }
}
