using System;

namespace Project06_ConfigNotify.Services
{
    public class NotificationConfig
    {
        public int DefaultNumberOfNotifications { get; set; } = 3;
        public string NotificationStyle { get; set; } = "Detailed"; // "Compact" or "Detailed"

        public event Action? OnConfigChanged;

        public void NotifyChanged()
        {
            OnConfigChanged?.Invoke();
        }
    }
}