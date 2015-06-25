using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using Core.ViewModels;

namespace Core
{
    public class App : MvxApplication
    {
        public App()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();            
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());            
        }       
    }
}