namespace ApiRabbitMQ.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        void SendProductMessage<T>(T message);
    }
}
