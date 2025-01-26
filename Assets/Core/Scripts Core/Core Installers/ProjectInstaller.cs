using UnityEngine;
using Zenject;
using Core.MVP;
using Core.Modules.SceneSwitcher;
using Core.Modules.TimeScaler;

namespace Core.Installers
{
	[CreateAssetMenu(menuName = "Core/Main Installers/Project Installer", order = 1)]
	public class ProjectInstaller : ScriptableObjectInstaller
    {
        [Header("UI Parametrs Settings")]
        [SerializeField] private UIParametrsSettings _UIParametrsSettings;

        [Header("SceneSwitcher Settings")]
        [SerializeField] private SceneSwitcherView _sceneSwitcherPrefab;
        [SerializeField] private SceneParametrsSettings _sceneParametrsSettings;

        public override void InstallBindings()
		{
            BindUIParametrs();
            BindSceneSwitcher();
            BindTimeScaler();
        }

        protected virtual void BindUIParametrs()
        {
            Container.Bind<UIParametrsSettings>().FromInstance(_UIParametrsSettings).AsSingle();
        }
        protected virtual void BindSceneSwitcher()
        {
            Container.BindInterfacesAndSelfTo<SceneSwitcherModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneSwitcherView>().FromComponentInNewPrefab(_sceneSwitcherPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<SceneSwitcherPresenter>().AsSingle().NonLazy();

            Container.Bind<SceneParametrsSettings>().FromInstance(_sceneParametrsSettings).AsSingle();
        }
        protected virtual void BindTimeScaler()
        {
            Container.BindInterfacesTo<TimeScalerService>().AsSingle();
        }
    }
}
