namespace Core.Modules.TimeScaler
{
    public interface ITimeScaler
    {
        /// <summary>
        /// Set Time to 1
        /// </summary>
        void SetDefault();

        /// <summary>
        /// Set Time to 0
        /// </summary>
        void SetStop();

        /// <summary>
        /// Set Time to Custom Time
        /// </summary>
        /// <param name="timeScale">Custom Time Scale</param>
        void SetScale(float timeScale);

        /// <summary>
        /// Returns Time Scale
        /// </summary>
        /// <returns>Time Scale</returns>
        float GetCurrentScale();
    }
}
