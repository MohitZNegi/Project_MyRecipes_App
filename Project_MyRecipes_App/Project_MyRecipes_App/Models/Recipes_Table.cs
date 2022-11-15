using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Project_MyRecipes_App.Models
{
    public class My_Recipes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
    }
}
