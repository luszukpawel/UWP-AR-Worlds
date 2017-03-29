using System.Collections.Generic;

using GalaSoft.MvvmLight.Views;

using AR_Worlds.Model;
using AR_Worlds.Service;

namespace AR_Worlds.ViewModel
{
    public sealed class SettingsViewModel : ViewModel
    {
        private readonly ISettings _settings;

        public SettingsViewModel(ISettings settings, INavigationService2 navigationService)
            : base(navigationService)
        {
            _settings = settings;
        }

        public string Theme
        {
            get
            {
                return _settings.Theme;
            }
            set
            {
                _settings.Theme = value;
            }
        }

        public IEnumerable<string> ThemeList => new List<string>() { "Light", "Dark" };
    }
}
