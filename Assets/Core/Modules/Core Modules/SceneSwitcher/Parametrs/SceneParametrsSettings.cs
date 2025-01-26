using UnityEngine;

namespace Core.Modules.SceneSwitcher
{
    [CreateAssetMenu(fileName = "Scene Settings", menuName = "Core/Parametrs/SceneSettings")]
    public class SceneParametrsSettings : ScriptableObject
    {
        [SerializeField] private string _mainMenuScene;
        [SerializeField] private string _gameScene;

        public string MainMenuScene
        {
            get { return _mainMenuScene; }
            private set { }
        }

        public string GameScene
        {
            get { return _gameScene; }
            private set { }
        }
    }
}
