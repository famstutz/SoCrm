using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoCrm.Test.WpfClient
{
    using SoCrm.Test.WpfClient.Customer;

    /// <summary>
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl
    {
        private CustomerServiceClient client;

        public AddressControl()
        {
            InitializeComponent();

            this.client = new CustomerServiceClient();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.AddressesDataGrid.ItemsSource = this.client.GetAllAddresses();
        }

        private void SaveNewAddressButton_Click(object sender, RoutedEventArgs e)
        {
            this.client.CreateAddress(
                this.AddressLineTextBox.Text, this.ZipCodeTextBox.Text, this.CityTextBox.Text, this.CountryTextBox.Text);
        }
    }
}
