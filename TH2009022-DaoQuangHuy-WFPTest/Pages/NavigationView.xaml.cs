using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TH2009022_DaoQuangHuy_WFPTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationView : Page
    {
        public NavigationView()
        {
            this.InitializeComponent();
        }
        private void nvSample_SelectionChanged(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var navigationViewItem = args.SelectedItem as NavigationViewItem;
            switch (navigationViewItem.Tag)
            {
                case "ListContact":
                    this.contentFrame.Navigate(typeof(MainPage));
                    break;
                case "AddContact":
                    this.contentFrame.Navigate(typeof(Pages.AddContacts));
                    break;
                case "SearchContact":
                    this.contentFrame.Navigate(typeof(Pages.SearchContact));
                    break;
            }
        }
    }
}
