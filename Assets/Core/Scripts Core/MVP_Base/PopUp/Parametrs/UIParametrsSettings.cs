using UnityEngine;

namespace Core.MVP
{
    [CreateAssetMenu(fileName = "UI Parametrs Settings", menuName = "Core/Parametrs/UIParametrsSettings")]
    public class UIParametrsSettings : ScriptableObject
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _scalingDuration;
        [SerializeField] private float _dropSpeed;

        public float FadeDuration => _fadeDuration;
        public float ScalingDuration => _scalingDuration;
        public float DropSpeed => _dropSpeed;
    }
}
