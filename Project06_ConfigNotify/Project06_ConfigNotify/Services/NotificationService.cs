namespace Project06_ConfigNotify.Services
{
    public class NotificationService
    {
        private readonly NotificationConfig _config;

        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }

        public Task<List<NotificationModel>> GetNotificationsAsync(int? numberOfNotifications = null)
        {
            int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;

            var mockAlerts = new List<NotificationModel>
            {
                new() { Id = 1, Title = "Security Token Refreshed", Message = "SSL authentication tunnel renegotiated successfully with remote core.", Timestamp = "Just now", Type = "success" },
                new() { Id = 2, Title = "Config Instance Sync", Message = "NotificationStyle state synchronized across active page nodes.", Timestamp = "4 mins ago", Type = "info" },
                new() { Id = 3, Title = "Memory Usage Alert", Message = "Scoped state lifecycle allocation reached 78% threshold marker.", Timestamp = "15 mins ago", Type = "warning" },
                new() { Id = 4, Title = "Background Service Init", Message = "Telemetry listener established async connection stack.", Timestamp = "1 hr ago", Type = "info" },
                new() { Id = 5, Title = "Deployment Complete", Message = "Pulse notification application compilation pushed to server.", Timestamp = "3 hrs ago", Type = "success" }
            };

            var result = mockAlerts.Take(Math.Min(count, mockAlerts.Count)).ToList();
            return Task.FromResult(result);
        }
    }

    public class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Timestamp { get; set; } = "";
        public string Type { get; set; } = "info"; // success, info, warning
    }
}
