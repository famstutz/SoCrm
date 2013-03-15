namespace SoCrm.Presentation.App.Commands
{
    using System.Collections.Generic;

    using SoCrm.Presentation.App.ViewModels;

    public class NavigateToViewCommand : WpfCommand
    {
        private readonly object _viewToNavigate;

        public NavigateToViewCommand(object viewToNavigate) : base("Navigate")
        {
            this._viewToNavigate = viewToNavigate;
        }

        protected override void RunCommand(object parameter)
        {
            Container.Container.GetA<IMainViewModel>().NavigateToView(this._viewToNavigate);
        }

        protected override IEnumerable<string> GetPreconditions(object parameter)
        {
            yield break;
        }
    }
}
