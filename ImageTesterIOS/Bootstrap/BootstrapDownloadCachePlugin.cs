using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore.Plugins;
using Foundation;
using UIKit;

namespace ImageTesterIOS.Bootstrap
{
    class BootstrapDownloadCachePlugin : MvxLoaderPluginBootstrapAction<Cirrious.MvvmCross.Plugins.DownloadCache.PluginLoader, Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>
    {
    }

    class BootstrapFilePlugin : MvxLoaderPluginBootstrapAction<Cirrious.MvvmCross.Plugins.File.PluginLoader, Cirrious.MvvmCross.Plugins.File.Touch.Plugin>
    {
    }
}