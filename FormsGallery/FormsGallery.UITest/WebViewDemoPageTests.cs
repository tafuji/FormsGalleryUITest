﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class WebViewDemoPageTests
    {
        IApp app;
        Platform platform;

        public WebViewDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WebViewDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("WebView");

            string marked = "WebViewDemoPage.WebView";

            if(platform == Platform.Android)
            {
                app.WaitForElement(x => x.Marked(marked), timeout: TimeSpan.FromSeconds(30));
                app.Query(x => x.Marked(marked).Invoke("setVisibility", 8));
                app.WaitForNoElement(x => x.Marked(marked), timeout: TimeSpan.FromSeconds(30));
            }
            else if(platform == Platform.iOS)
            {


            }
            app.Back();
        }
    }
}

