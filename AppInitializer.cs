using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestDemo.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            string configfilepath = @"D:\Jayanth Frameworks\Xamarin_Framework\Framework_Xamarin\Sampleappforxamarinapp\configfile.txt";
            string Config = File.ReadAllText(configfilepath);
            string[] value = Config.Split('=');
            string APP = value[0];
            string APPPath = value[1];


            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile(APPPath).StartApp();

            }

            return ConfigureApp.iOS.AppBundle(APPPath).StartApp();
        }
    }
}