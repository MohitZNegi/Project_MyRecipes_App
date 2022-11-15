using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Project_MyRecipes_App.Models;


namespace Project_MyRecipes_App.Views
{

    public partial class MyRecipes : ContentPage
    {
      
        public MyRecipes()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetRecipesAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
             {
                 // Navigate to the AddPage, passing the ID as a query parameter.
                 My_Recipes recipe = (My_Recipes)e.CurrentSelection.FirstOrDefault();
                 await Shell.Current.GoToAsync($"{nameof(ReadRecipePage)}?{nameof(ReadRecipePage.ItemId)}={recipe.ID.ToString()}");
             } 

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Navigate to the AddPage.
            await Navigation.PushAsync(new AddPage());
        }

    }
}