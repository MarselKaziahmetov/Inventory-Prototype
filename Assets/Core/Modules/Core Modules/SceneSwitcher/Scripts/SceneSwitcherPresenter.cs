using Core.MVP;

namespace Core.Modules.SceneSwitcher
{
    public class SceneSwitcherPresenter : PresenterBase<SceneSwitcherModel, SceneSwitcherView>
    {
        protected override void Present()
        {
            Model.FadeInRequested += Model_FadeInRequested;
            Model.FadeOutRequested += Model_SceneLoaded;

            View.OnFadeIn += View_Faded;

            View.Switch += View_SwitchScene;
        }

        public override void Dispose()
        {
            Model.FadeInRequested -= Model_FadeInRequested;
            Model.FadeOutRequested -= Model_SceneLoaded;

            View.OnFadeIn -= View_Faded;

            View.Switch -= View_SwitchScene;
        }

        private void Model_FadeInRequested()
        {
            View.FadeInView();
        }

        private void View_Faded()
        {
            Model.LoadNewScene();
        }

        private void Model_SceneLoaded()
        {
            View.FadeOutView();
        }

        private void View_SwitchScene(string sceneName)
        {
            Model.SwitchSceneTo(sceneName);
        }
    }

}
