using AmazonQueue.MessageBus;
using AmazonQueue.MessageBus.Integration;

namespace AmazonQueue.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var busService = new MessageBusService("__AWS_ACCESS_KEY__", "__AWS_SECRET_KEY__");

            while (true)
            {
                Console.Write("Código do Carrinho: ");

                int id = int.Parse(Console.ReadLine());

                // Queue
                var evt = new CartCreatedIntegrationEvent(id, "Anderson");
                var queueUrl = await busService.GetQueueUrl(QueueTypes.AWS_SQS_CART_CREATED);
                await busService.SendAsync(queueUrl, evt);

                // Tópico
                // var evt = new UserCreatedIntegrationEvent(id);
                // var topicArn = await busService.GetTopicArn(TopicTypes.AWS_SNS_USER_CREATED);
                // await busService.PublishAsync(topicArn, evt);

            }
        }
    }
}
