using Project_MyRecipes_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Project_MyRecipes_App.Views
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