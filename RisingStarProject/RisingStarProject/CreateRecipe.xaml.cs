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
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static RisingStarProject.RecipeModel.Program;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateRecipe : Page
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private StringBuilder sb = new StringBuilder();
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private Recipe recipe = new Recipe();
        public CreateRecipe()
        {
            this.InitializeComponent();
            RecipeDisplay.ItemsSource = recipes;
        }

        private void Create_Ingredients(object sender, TappedRoutedEventArgs e)
        {
            //Store the fields from text boxes

            string ingredientName = IngredientNameTextBox.Text;

            string type = IngredientTypeTextBox.Text;

            float quantity = float.Parse(QuantityTextBox.Text);

            string measurement = MeasurementTextBox.Text;

            //Create a newIngredient from the fields

            Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement};

            //In the recipe add the ingredient
            recipe.Ingredients.Add(newIngredient);

            IngredientNameTextBox.Text = "Ingredient Name";
            IngredientTypeTextBox.Text = "Ingredient Type";
            QuantityTextBox.Text = "Ingredient Quantity";
            MeasurementTextBox.Text = "Measurement Type";
        }
        private void Create_Recipe(object sender, TappedRoutedEventArgs e)
        {

            //Store information into a new recipe

            string recipeName = RecipeNameTextBox.Text;
            string recipeType = RecipeTypeTextBox.Text;
            recipe.Name = recipeName;
            recipe.Type = recipeType;

            //Add a new recipe to the recipes List
            recipes.Add(recipe);
            RecipeNameTextBox.Text = "Recipe Name";
            RecipeTypeTextBox.Text = "Recipe Type";
            recipe = new Recipe();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Recipe> && e.Parameter != null)
            {
                ObservableCollection<Recipe> oldRecipes = e.Parameter as ObservableCollection<Recipe>;
                if (oldRecipes.Count != 0)
                {
                    foreach (Recipe r in oldRecipes)
                    {
                        recipes.Add(r);
                    }
                }
            }
            base.OnNavigatedTo(e);
        }

        private void BackToHomePage(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), recipes);
        }
    }
}
