using System;

namespace Project05_AuthState.Services
{
    public class AuthenticationStateService
    {
        public bool IsAuthenticated { get; private set; } = false;
        public string CurrentUser { get; private set; } = "Guest User";

        public event Action? OnStateChanged;

        public void LogIn(string username)
        {
            IsAuthenticated = true;
            CurrentUser = string.IsNullOrWhiteSpace(username) ? "Administrator" : username;
            NotifyStateChanged();
        }

        public void LogOut()
        {
            IsAuthenticated = false;
            CurrentUser = "Guest User";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}