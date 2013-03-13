namespace SoCrm.Test.WpfClient
{
    using System;
    using System.Windows;

    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Test.WpfClient.LoggingService;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoggingServiceClient client;

        public MainWindow()
        {
            InitializeComponent();

            this.client = new LoggingServiceClient();

            this.TimestampTextBox.Text = DateTime.Now.ToString();
        }

        private void NewLogEventButton_Click(object sender, RoutedEventArgs e)
        {
            this.client.Log(
                this.MessageTextBox.Text,
                (Severity)Enum.Parse(typeof(Severity), this.SeverityComboBox.Text),
                DateTime.Parse(this.TimestampTextBox.Text));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.LogEventsDataGrid.ItemsSource = this.client.GetAll();
        }
    }
}
