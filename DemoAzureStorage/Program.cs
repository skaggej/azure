using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DemoAzureStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What do you need to do? - ");
            string taskDescription = Console.ReadLine();
            CloudTableClient ct = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudTableClient();
            CloudTable taskTable = ct.GetTableReference("PersonalTasks");
            taskTable.CreateIfNotExists();
            PersonalTaskEntity newPersonalTask = new PersonalTaskEntity("personal",Guid.NewGuid().ToString());
            newPersonalTask.PersonalTaskDescription = taskDescription;
            TableOperation insertTaskOperation = TableOperation.Insert(newPersonalTask);
            taskTable.Execute(insertTaskOperation);
        }
    }
        
    public class PersonalTaskEntity : TableEntity
    {
        public string PersonalTaskDescription { get; set; }

        public PersonalTaskEntity() { }

        public PersonalTaskEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }
    }
}
