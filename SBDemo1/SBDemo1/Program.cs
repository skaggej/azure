using Microsoft.Azure;
using Microsoft.ServiceBus;

namespace SBDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the topic if it does not exist already.
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);            
            if (!namespaceManager.TopicExists("TestTopic"))
            {
                namespaceManager.CreateTopic("TestTopic");
            }
        }
    }
}