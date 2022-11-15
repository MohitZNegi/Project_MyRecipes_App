using System;
using SQLite;
namespace Project_MyRecipes_App.Models
{
    public class Item
    {

        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
    }
}