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
    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Test.WpfClient.Logging;

    /// <summary>
    /// Interaction logic for LogEventControl.xaml
    /// </summary>
    public partial class LogEventControl : UserControl, IDisposable
    {
         private LoggingServiceClient client;

        public LogEventControl()
        {
            InitializeComponent();

            this.client = new LoggingServiceClient();

            this.SeverityComboBox.ItemsSource = this.client.GetAllSeverities();
            this.TimestampTextBox.Text = DateTime.Now.ToString();
        }

        private void NewLogEventButton_Click(object sender, RoutedEventArgs e)
        {
            this.client.LogEvent(
                this.MessageTextBox.Text,
                (Severity)Enum.Parse(typeof(Severity), this.SeverityComboBox.Text),
                DateTime.Parse(this.TimestampTextBox.Text));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.LogEventsDataGrid.ItemsSource = this.client.GetAllLogEvents();
        }

        public void Dispose()
        {
            this.client.Close();
        }
    }
}
