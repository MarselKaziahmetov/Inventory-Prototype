using UnityEngine;

namespace Core.Modules.TimeScaler
{
    public class TimeScalerService : ITimeScaler
    {
        public void SetDefault()
        {
            Time.timeScale = 1.0f;
        }

        public void SetStop()
        {
            Time.timeScale = 0.0f;
        }

        public void SetScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public float GetCurrentScale()
        {
            return Time.timeScale;
        }
    }
}
