using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Dark.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }

    
    public static string Mail
    {
        get
        {
            return AppSettings.GetValueOrDefault("Mail","");
        }
        set
        {
            AppSettings.AddOrUpdateValue("Mail", value);
        }
    }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

    }
}
