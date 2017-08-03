using RabbitMQ.Client;
using System.Text;
using System.Windows;

namespace Test.RabbitMq.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ConnectionFactory factory;
        public MainWindow()
        {
            InitializeComponent();
            factory = new ConnectionFactory() { HostName = "localhost" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "Siri",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    string message = Txt.Text;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "Siri",
                        basicProperties: null,
                        body: body
                        );

                    TxtSend.AppendText("\r\n" + message);
                    Txt.Text = string.Empty;
                }
            }
        }
    }
}
