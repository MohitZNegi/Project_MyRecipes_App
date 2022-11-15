using Project_MyRecipes_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Xamarin.Essentials;
using SQLite;


namespace Project_MyRecipes_App.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;


            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Recipes_Data.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Item>();
        }

        readonly List<Item> items;
         
        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
                
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await Init();
           
            items.Add(item);
           

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await Init();
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            await Init();
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await Init();
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await Init();
            return await Task.FromResult(items);
        }

        private class SQLiteAsynConnection
        {
        }
    }
}