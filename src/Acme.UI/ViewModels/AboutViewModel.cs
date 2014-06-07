namespace Acme.UI.ViewModels
{
    public class AboutViewModel
    {
        public string[] TechnologyList { get; set; }

        public AboutViewModel()
        {
            TechnologyList = new [] 
            {
                "Modern UI", "Charts", "MVVM", "PRISM", "Unity", "Pub/Sub Event Aggregator", "Logging service",
                "Task Parallel Library", "Async and await", "Data templates", "Optional Fake in memory data", "Key press binding",
                "Confirmation dialogs from view model", "Gradients", "Unit tests with MOQ", "MSTestExtensions", "MoreLINQ for batching", "IoC", 
                "Portable class library shared DTOs", "Web API 2 on Server", "Web API client library", "REST with JSON", "DAPPER ORM", 
                "Factories", "Repositories", "Strategy design patterns", "SQL Server with stored procs", "and many more!"
            };
        }
    }
}
