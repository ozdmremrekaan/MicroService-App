namespace Mango.Services.EmailAPI.RabbitMQMessageSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(object message,string queueName);
    }
}
