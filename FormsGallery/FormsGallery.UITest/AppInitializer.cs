using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp(@"com.xamarin.forms.formsgallery")
                    .EnableLocalScreenshots()
                    .StartApp();
            }


            // Get the app file path by using assembly path
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            Uri appUri = new Uri(uri.Uri, "../../../FormsGallery.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone10.4-11.2/FormsGallery.iOS.app");

            return ConfigureApp
                .iOS
                .DeviceIdentifier("63E4A5C6-0D8A-4540-95FC-52B6E7B99EC4") // iPhone 8
                .AppBundle(appUri.AbsolutePath)
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}

