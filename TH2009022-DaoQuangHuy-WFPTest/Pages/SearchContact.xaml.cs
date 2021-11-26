using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TH2009022_DaoQuangHuy_WFPTest.Model;
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
    public sealed partial class SearchContact : Page
    {
        private ContactModel contactModel = new ContactModel();
        public SearchContact()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = contactModel.SearchByKeyword(txtName.Text);
            if (result.Count == 0)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Contact not found";
                contentDialog.PrimaryButtonText = "Try again!";
                await contentDialog.ShowAsync();
            }
            MyListView.ItemsSource = result;
        }
    }
}
