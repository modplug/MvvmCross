using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using Core;
using Foundation;
using UIKit;

namespace ImageTesterIOS
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate appDelegate, IMvxTouchViewPresenter presenter)
            : base(appDelegate, presenter)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override List<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies;
//                toReturn.Add(typeof(MvxLanguageConverter).Assembly);
                //                toReturn.Add(typeof(MvxNativeColorValueConverter).Assembly);
                return toReturn;
            }
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();

            base.AddPluginsLoaders(registry);

        }

        protected override void InitializeLastChance()
        {
            
//            Cirrious.MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();
//            Cirrious.MvvmCross.Plugins.File.Touch.Plugin();
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();

            base.InitializeLastChance();
        }

        protected override void InitializeFirstChance()
        {

        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
//            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
//            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();
//            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
//            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance>();
            base.LoadPlugins(pluginManager);
        }
    }
}