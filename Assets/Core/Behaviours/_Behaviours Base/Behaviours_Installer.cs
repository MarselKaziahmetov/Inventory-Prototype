using UnityEngine;
using Zenject;

namespace Core.Behaviours
{
	[CreateAssetMenu(menuName = "Core/Main Installers/Behaviours Installer")]
	public class Behaviours_Installer : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			BindDefaultBehaviours();

			BindExtendedBahaviours();

			Container.BindInterfacesAndSelfTo<BehaviourEnabler>().AsSingle().NonLazy();
		}


		public virtual void BindDefaultBehaviours()
		{
            //Container.BindInterfacesTo<MainSceneLoaderBehaviour>().AsSingle();
        }

		public virtual void BindExtendedBahaviours()
		{
		}
	}
}
