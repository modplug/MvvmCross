﻿using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using Core.ViewModels;
using CoreGraphics;
using UIKit;

namespace ImageTesterIOS
{
    public partial class RootViewController : MvxViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public RootViewController()
        {
            
        }

        public RootViewController(IntPtr handle)
            : base(handle)
        {
        }

        public new MainViewModel ViewModel
        {
            get {  return (MainViewModel)base.ViewModel; }
            set { ViewModel = value; }
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            NavigationController.SetNavigationBarHidden(true, false);
            base.ViewDidLoad();

            UITableViewController friendsTableViewController = new UITableViewController();
            var refreshControl = new MvxUIRefreshControl {Message = "Refreshing items"};
            friendsTableViewController.RefreshControl = refreshControl;
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Height;
            UITableView tableView = new UITableView(new CGRect(0, statusBarHeight, View.Frame.Width, View.Frame.Height - statusBarHeight));
            friendsTableViewController.TableView = tableView;
            Add(tableView);
            AutomaticallyAdjustsScrollViewInsets = true;
           
            var tableViewSource = new MvxStandardTableViewSource(tableView, "TitleText Title;ImageUrl Url");
            tableView.Source = tableViewSource;

            var set = this.CreateBindingSet<RootViewController, MainViewModel>();
            set.Bind(tableViewSource).To(vm => vm.Urls);
            set.Bind(refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshListCommand);
            set.Bind(refreshControl).For(r => r.IsRefreshing).To(vm => vm.IsLoading);
            set.Apply();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            

            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}