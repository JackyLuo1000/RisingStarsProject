using RisingStarProject;
using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static RisingStarProject.RecipeModel.Program;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void CreateRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateRecipe), recipes);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Recipe> && e.Parameter != null)
            {
                ObservableCollection<Recipe> oldRecipes = e.Parameter as ObservableCollection<Recipe>;
                if(oldRecipes.Count != 0)
                {
                    foreach (Recipe r in oldRecipes)
                    {
                        recipes.Add(r);
                    }
                }
            }
            base.OnNavigatedTo(e);
        }

        private void Name_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ingredient_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Type_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Recipe_Display(object sender, RoutedEventArgs e)
        {

        }
    }
}
