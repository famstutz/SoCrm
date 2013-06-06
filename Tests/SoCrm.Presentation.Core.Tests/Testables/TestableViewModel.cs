namespace SoCrm.Presentation.Core.Tests.Testables
{
    public class TestableViewModel : ViewModelBase
    {
        private string value;

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                this.OnPropertyChanged("Value");
            }
        }
    }
}
