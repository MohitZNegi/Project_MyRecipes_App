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
    public partial class AddPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecipe(value);
            }
        }
        public AddPage()
        {
            InitializeComponent();
            // Set the BindingContext of the page to a new recipe.
            BindingContext = new My_Recipes();
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

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {   //Save and Update
            var recipe = (My_Recipes)BindingContext;
            if (!string.IsNullOrWhiteSpace(recipe.Title) && !string.IsNullOrWhiteSpace(recipe.CreatedBy)
                && !string.IsNullOrWhiteSpace(recipe.Ingredients) && !string.IsNullOrWhiteSpace(recipe.Steps))
            {
                await App.Database.SaveRecipeAsync(recipe);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (My_Recipes)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}
