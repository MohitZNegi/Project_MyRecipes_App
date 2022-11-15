using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_MyRecipes_App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_MyRecipes_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ReadRecipePage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecipe(value);
               
            }
        }
        public ReadRecipePage()
        {
            InitializeComponent();
        }

        async void LoadRecipe(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the recipe and set it as the BindingContext of the page.
                My_Recipes recipe = await App.Database.GetRecipeAsync(id);
                BindingContext = recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Recipe.");
            }
        }



        async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            // get the selected recipe data to update and delete 
            var recipe = (My_Recipes)BindingContext;
            await Shell.Current.GoToAsync($"{nameof(AddPage)}?{nameof(AddPage.ItemId)}={recipe.ID.ToString()}");

        }
    }
}