using System;

namespace Core.Modules.SceneSwitcher
{
    public interface ISceneSwitcher
    {
        event Action FadeInRequested;
        event Action FadeOutRequested;
        void SwitchSceneTo(string newScene);
        void LoadNewScene();
    }
}
