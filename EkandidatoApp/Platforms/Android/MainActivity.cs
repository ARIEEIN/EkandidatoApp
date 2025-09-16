using Android.App;
using Android.Content.PM;
using Android.OS;

namespace EkandidatoApp
{
    [Activity(Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,  
        ConfigurationChanges = ConfigChanges.ScreenSize 
        | ConfigChanges.Orientation 
        | ConfigChanges.UiMode 
        | ConfigChanges.ScreenLayout 
        | ConfigChanges.SmallestScreenSize 
        | ConfigChanges.Density,
        LaunchMode = LaunchMode.SingleTask,
        WindowSoftInputMode = Android.Views.SoftInput.AdjustPan)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
