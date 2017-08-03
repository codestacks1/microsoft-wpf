using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Windows;

namespace RabbitMq.Server
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

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        TxtReceived.AppendText(message + "\r\n");
                    };

                    channel.BasicConsume(
                        queue: "Siri",
                        noAck: true,
                        consumer: consumer
                        );
                }
            }
        }
    }
}
