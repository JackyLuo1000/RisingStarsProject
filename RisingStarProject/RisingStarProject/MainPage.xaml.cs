using RisingStarProject;
using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private StringBuilder sb = new StringBuilder();
        //private List<Recipe> recipes = new List<Recipe>();
        public MainPage()
        {
            this.InitializeComponent();
            //recipes.Add(new Recipe);
        }

        private void Create_New_Recipe(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Ingredients(object sender, RoutedEventArgs e)
        {
            //Store the fields from text boxes

            //string IngredientName = IngredientNameTextBox.Text;

            //string Type = TypeTextBox.Text;

            //float quantity = float.Parse(QuantityTextBox.Text);

            //string measurement = MeasurementTextBox.Text;

            //Create a newIngredient from the fields

            //Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement};
            
            //In the recipe add the ingredient

            //recipes.Last().Ingredients.Add(newIngredient);
        }
        private void Create_Recipe(object sender, RoutedEventArgs e)
        {

            //Store information into a new recipe

            //string recipeName = RecipeNameTextBox.Text
            //recipes.Last().Name = recipeName
            
            //Add a new recipe to the recipes List
            //recipes.Add(new Recipe)
        }

        private async void Preview_Recipe(object sender, RoutedEventArgs e)
        {

            //Store information into a new recipe

            //await (new MessageDialog(recipes.Last().toString()).ShowAsync())
        }
    }
}
