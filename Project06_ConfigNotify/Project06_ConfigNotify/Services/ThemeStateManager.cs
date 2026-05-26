using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Project06_ConfigNotify.Services
{
    public class ThemeStateManager
    {
        private readonly ProtectedLocalStorage _localStorage;
        public string CurrentThemeClass { get; private set; } = "app-light-theme";

        public event Action? OnThemeStateChanged;

        public ThemeStateManager(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadSavedThemeAsync()
        {
            try
            {
                var result = await _localStorage.GetAsync<string>("userAppTheme");
                if (result.Success && !string.IsNullOrEmpty(result.Value))
                {
                    CurrentThemeClass = result.Value;
                }
                NotifyStateChanged();
            }
            catch
            {
                CurrentThemeClass = "app-light-theme";
            }
        }

        public async Task ToggleThemeAsync()
        {
            
            CurrentThemeClass = (CurrentThemeClass == "app-light-theme") ? "app-dark-theme" : "app-light-theme";
            try
            {
                await _localStorage.SetAsync("userAppTheme", CurrentThemeClass);
            }
            catch { }
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnThemeStateChanged?.Invoke();
    }
}