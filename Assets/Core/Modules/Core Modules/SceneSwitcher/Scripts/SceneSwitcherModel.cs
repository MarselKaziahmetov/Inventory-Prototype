using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Modules.SceneSwitcher
{
    public class SceneSwitcherModel : ISceneSwitcher
    {
        public event Action FadeInRequested;
        public event Action FadeOutRequested;

        private string _newSceneName;

        public void SwitchSceneTo(string newScene)
        {
            _newSceneName = newScene;
            FadeInRequested?.Invoke();
        }

        public void LoadNewScene()
        {
            var asyncOperation = SceneManager.LoadSceneAsync(_newSceneName);
            asyncOperation.completed += OnSceneLoaded; 
        }

        private void OnSceneLoaded(AsyncOperation asyncOperation)
        {
            FadeOutRequested?.Invoke(); 
        }
    }
}
