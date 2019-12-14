using System;
using System.IO;
using System.Linq;
using System.Threading;
using EmbeddedResources;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestDemo.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]

    public class Tests
    {
        IApp app;
        Platform platform;
       

        public Tests(Platform platform)
        {
            this.platform = platform;

        }

        [SetUp]
        public void TestSetup()
        {
            app = AppInitializer.StartApp(platform);
            

        }

        [Test]
        public void AppLaunches()
        {
            
            string text_report= "TestReportStart/**************************/" + "\n" + "Step Name" + "\t" + "Parameter" + "\t" + "Action" + "\t" + "Locator type" + "\t" + "Locator" + "\t" + "Expected" + "\t" + "Observed" + "\n";
            string Path = @"D:\Jayanth Frameworks\Xamarin_Framework\Framework_Xamarin\Sampleappforxamarinapp\Testreport.txt";
            File.WriteAllText(Path, String.Empty);
            File.AppendAllText(Path, text_report);

            string[] Testdata = File.ReadAllLines(@"D:\Jayanth Frameworks\Xamarin_Framework\Framework_Xamarin\Sampleappforxamarinapp\Testdata.txt");

            for (int i = 1; i <= Testdata.Length; i++)
            {

                
                string[] Sample = Testdata[i].Split('\t');
                string Stepname = Sample[0].ToString();
                string Parameter = Sample[1].ToString();
                string Action = Sample[2].ToString();
                string LocatorType = Sample[3].ToString();
                string Locator = Sample[4].ToString();
                string EXpected = Sample[5].ToString();
                string Index = Sample[6].ToString();
                string obs_val = "";
                string stepdata = "";

                try
                {
                    switch (Action)
                    {
                        case "Tap":

                            if (LocatorType == "Text")
                            {
                                int index = Int32.Parse(Index);

                                app.Screenshot(Stepname);
                                app.Tap(x => x.Text(Locator).Index(index));
                            }
                            if (LocatorType == "ID")
                            {
                                int index = Int32.Parse(Index);
                                
                                app.Screenshot(Stepname);
                                app.Tap(x => x.Id(Locator).Index(index));
                            }
                            if (LocatorType == "Class")
                            {
                                int index = Int32.Parse(Index);
                                
                                app.Screenshot(Stepname);
                                app.Tap(x => x.Class(Locator).Index(index));
                            }
                            if (LocatorType == "css")
                            {
                                int index = Int32.Parse(Index);
                                
                                app.Screenshot(Stepname);
                                app.Tap(x => x.Css(Locator).Index(index));
                            }
                            if (LocatorType == "Xpath")
                            {
                                int index = Int32.Parse(Index);
                                
                                app.Screenshot(Stepname);
                                app.Tap(x => x.XPath(Locator).Index(index));
                            }

                            obs_val = "Tapped";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                        case "Scrolldown":
                            app.ScrollDown();
                            app.Screenshot(Stepname);
                            obs_val = "Scrolled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Scrolluntil":

                            if (LocatorType == "Text")
                            {
                                int index = Int32.Parse(Index);
                                app.ScrollDownTo(x => x.Text(Locator).Index(index));
                                app.Screenshot(Stepname);
                            }
                            if (LocatorType == "ID")
                            {
                                int index = Int32.Parse(Index);
                                app.ScrollDownTo(x => x.Id(Locator).Index(index));
                                app.Screenshot(Stepname);
                            }
                            if (LocatorType == "Class")
                            {
                                int index = Int32.Parse(Index);
                                app.ScrollDownTo(x => x.Class(Locator).Index(index));
                                app.Screenshot(Stepname);
                            }
                            if (LocatorType == "css")
                            {
                                int index = Int32.Parse(Index);
                                app.ScrollDownTo(x => x.Css(Locator).Index(index));
                                app.Screenshot(Stepname);
                            }
                            if (LocatorType == "Xpath")
                            {
                                int index = Int32.Parse(Index);
                                app.ScrollDownTo(x => x.XPath(LocatorType).Index(index));
                                app.Screenshot(Stepname);
                            }
                            obs_val = "ScrollUntilSuccess";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Sendkeys":
                            if (LocatorType == "Text")
                            {
                                
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Text(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 20, 0));

                                app.EnterText(x => x.Text(Locator).Index(index), EXpected);
                                app.ClearText();
                                app.EnterText(x => x.Text(Locator).Index(index), EXpected);
                                app.Screenshot(Stepname);
                                app.DismissKeyboard();
                            }
                            if (LocatorType == "ID")
                            {
                                
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Id(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 20, 0));
                                app.EnterText(x => x.Id(Locator).Index(index), EXpected);
                                app.ClearText();
                                app.EnterText(x => x.Id(Locator).Index(index), EXpected);
                                app.Screenshot(Stepname);
                                app.DismissKeyboard();
                            }
                            if (LocatorType == "Class")
                            {
                               
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Class(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 20, 0));
                                app.EnterText(x => x.Class(Locator).Index(index), EXpected);
                                app.ClearText();
                                app.EnterText(x => x.Class(Locator).Index(index), EXpected);
                                app.Screenshot(Stepname);
                                app.DismissKeyboard();
                            }
                            if (LocatorType == "css")
                            {
                                
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Css(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 20, 0));
                                app.EnterText(x => x.Css(Locator).Index(index), EXpected);
                                app.ClearText();
                                app.EnterText(x => x.Css(Locator).Index(index), EXpected);
                                app.Screenshot(Stepname);
                                app.DismissKeyboard();
                            }
                            if (LocatorType == "Xpath")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.XPath(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 20, 0));
                                app.EnterText(x => x.XPath(Locator).Index(index), EXpected);
                                app.ClearText();
                                app.EnterText(x => x.XPath(Locator).Index(index), EXpected);
                                app.Screenshot(Stepname);
                                app.DismissKeyboard();
                            }
                            obs_val = "SendKeysSuccess";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "ReadText":
                            string Textread = "";
                            if (LocatorType == "Text")
                            {
                                int index = Int32.Parse(Index);
                                Textread = app.Query(x => x.Text(Locator).Index(index))[0].Text;
                                app.Screenshot(Stepname);

                            }
                            if (LocatorType == "ID")
                            {
                                int index = Int32.Parse(Index);
                                Textread = app.Query(x => x.Id(Locator).Index(index))[0].Text;
                                app.Screenshot(Stepname);
                            }
                            if (LocatorType == "Class")
                            {

                                int index = Int32.Parse(Index);
                                Textread = app.Query(x => x.Class(Locator).Index(index))[0].Text;
                                app.Screenshot(Stepname);

                            }
                           
                            obs_val = Textread;
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val;
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Screenshot":
                            app.Screenshot(Stepname);
                            
                            obs_val = "ScreenShotCaptured";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val;
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Waitforelement":

                            if (LocatorType == "Text")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Text(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 60, 0));
                            }
                            if (LocatorType == "ID")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Id(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 60, 0));
                            }
                            if (LocatorType == "Class")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Class(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 60, 0));
                            }
                            if (LocatorType == "css")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.Css(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 60, 0));
                            }
                            if (LocatorType == "Xpath")
                            {
                                int index = Int32.Parse(Index);
                                app.WaitForElement(x => x.XPath(Locator).Index(index), "Did not see the element.", new TimeSpan(0, 0, 0, 60, 0));

                            }
                            obs_val = "ElementFound";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Locatoracess":
                            app.Repl();
                            obs_val = "ReplLaunched";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Delay":

                            int Time = Int32.Parse(EXpected);
                            Thread.Sleep(Time);
                            obs_val = "waitsuccess";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Wifienable":
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/C adb shell svc wifi enable";

                            
                            process.StartInfo = startInfo;
                            process.Start();
                            obs_val = "Wifi_enabled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                        case "Wifidisable":
                            System.Diagnostics.Process testprocess = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo cmdstartInfo = new System.Diagnostics.ProcessStartInfo();
                            cmdstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            cmdstartInfo.FileName = "cmd.exe";
                            
                            cmdstartInfo.Arguments = "/C adb shell svc wifi disable";
                            testprocess.StartInfo = cmdstartInfo;
                            testprocess.Start();
                            obs_val = "Wifi_disabled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                        case "Bluetoothenable":

                            System.Diagnostics.Process testprocessblu = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo cmdstartInfoblu = new System.Diagnostics.ProcessStartInfo();
                            cmdstartInfoblu.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            cmdstartInfoblu.FileName = "cmd.exe";
                            cmdstartInfoblu.Arguments = "/C adb shell service call bluetooth_manager 6";
                            testprocessblu.StartInfo = cmdstartInfoblu;
                            testprocessblu.Start();
                            obs_val = "Bluetooth_enabled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                        case "Bluetoothdisable":

                            System.Diagnostics.Process testprocessBluoff = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo cmdstartInfoBluoff = new System.Diagnostics.ProcessStartInfo();
                            cmdstartInfoBluoff.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            cmdstartInfoBluoff.FileName = "cmd.exe";
                            cmdstartInfoBluoff.Arguments = "/C adb shell service call bluetooth_manager 9";
                            testprocessBluoff.StartInfo = cmdstartInfoBluoff;
                            testprocessBluoff.Start();
                            obs_val = "Bluetooth_disabled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                        case "Mobiledataoff":
                            System.Diagnostics.Process processdata = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfodata = new System.Diagnostics.ProcessStartInfo();
                            startInfodata.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfodata.FileName = "cmd.exe";
                            startInfodata.Arguments = "/C adb shell svc data disable";

                            
                            processdata.StartInfo = startInfodata;
                            processdata.Start();
                            obs_val = "MobileData_disabled";
                            stepdata = stepdata + Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);
                            break;
                        case "Mobiledataon":
                            System.Diagnostics.Process processdataon = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfodataon = new System.Diagnostics.ProcessStartInfo();
                            startInfodataon.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfodataon.FileName = "cmd.exe";
                            startInfodataon.Arguments = "/C adb shell svc data enable";

                            
                            processdataon.StartInfo = startInfodataon;
                            processdataon.Start();
                            obs_val = "MobileData_enabled";
                            stepdata = Stepname + "\t" + Parameter + "\t" + Action + "\t" + LocatorType + "\t" + Locator + "\t" + EXpected + "\t" + obs_val + "\n";
                            File.AppendAllText(Path, stepdata);

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    obs_val = "Error:" + e.Message.ToString();
                    File.AppendAllText(Path, obs_val);

                }


            }




        }

    }

}

