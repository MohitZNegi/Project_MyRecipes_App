using Project_MyRecipes_App.ViewModels;
using Project_MyRecipes_App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project_MyRecipes_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(ReadRecipePage), typeof(ReadRecipePage));
        }

    }
}
