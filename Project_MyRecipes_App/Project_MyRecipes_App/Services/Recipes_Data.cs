using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Project_MyRecipes_App.Models;

namespace Project_MyRecipes_App.Views
{
    public class Recipes_Data
    {
        readonly SQLiteAsyncConnection database;

        public Recipes_Data(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<My_Recipes>().Wait();
        }

        public Task<List<My_Recipes>> GetRecipesAsync()
        {
            //Get all recipes.
            return database.Table<My_Recipes>().ToListAsync();
        }

        public Task<My_Recipes> GetRecipeAsync(int id)
        {
            // Get a specific recipe.
            return database.Table<My_Recipes>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(My_Recipes recipe)
        {
            if (recipe.ID != 0)
            {
                // Update an existing recipe.
                return database.UpdateAsync(recipe);
            }
            else
            {
                // Save a new recipe.
                return database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(My_Recipes recipe)
        {
            // Delete a note.
            return database.DeleteAsync(recipe);
        }

    }
}
