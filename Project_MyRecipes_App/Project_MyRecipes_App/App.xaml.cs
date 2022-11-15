using Project_MyRecipes_App.Services;
using Project_MyRecipes_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Project_MyRecipes_App
{
    public partial class App : Application
    {
        static Recipes_Data database;

        // Create the database connection as a singleton.
        public static Recipes_Data Database
        {
            get
            {
                if (database == null)
                {
                    database = new Recipes_Data(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyRecipes.db"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
