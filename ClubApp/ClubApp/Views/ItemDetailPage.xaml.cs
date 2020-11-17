using ClubApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClubApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}