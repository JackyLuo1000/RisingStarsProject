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
        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        private StringBuilder sb = new StringBuilder();
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private Recipe recipe = new Recipe();
        private ObservableCollection<Recipe> oldRecipes = new ObservableCollection<Recipe>();
        private int recipeIndex = 0;
        private int ingredientIndex = -1;
        public CreateRecipe()
        {
            this.InitializeComponent();
            RecipeDisplay.ItemsSource = recipes;

        }

        private void AddIngedient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ingredientIndex == -1)
            {

                //Store the fields from text boxes

                string ingredientName = IngredientNameTextBox.Text;

                string type = IngredientTypeTextBox.Text;

                float quantity = float.Parse(QuantityTextBox.Text);

                string measurement = MeasurementTextBox.Text;

                //Create a newIngredient from the fields

                Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement };

                //In the recipe add the ingredient
                recipes[recipeIndex].Ingredients.Add(newIngredient);
            }
            else
            {
                string ingredientName = IngredientNameTextBox.Text;

                string type = IngredientTypeTextBox.Text;

                float quantity = float.Parse(QuantityTextBox.Text);

                string measurement = MeasurementTextBox.Text;

                Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement };
                recipes[recipeIndex].Ingredients[ingredientIndex] = newIngredient;
            }
            
            IngredientNameTextBox.Text = "";
            IngredientTypeTextBox.Text = "";
            QuantityTextBox.Text = "";
            MeasurementTextBox.Text = "";
        }
        private void SaveRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //Store information into a new recipe

            recipes.Add(new Recipe());
            recipeIndex++;


            //Add a new recipe to the recipes List
            RecipeNameTextBox.Text = "New Recipe";
            RecipeTypeTextBox.Text = "New Recipe Type";
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
                else
                {
                    recipes.Add(new Recipe());
                }
            }
            base.OnNavigatedTo(e);
        }

        private void BackToMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(recipes.Last().Name) || string.IsNullOrEmpty(recipes.Last().Type))
            {
                recipes.RemoveAt(recipes.Count - 1);
            }
            if(recipes.Last().Name == "New Recipe" && recipes.Last().Type == "New Recipe Type")
            {
                recipes.RemoveAt(recipes.Count - 1);
            }
            this.Frame.Navigate(typeof(MainPage), recipes);
        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           string recipeName = RecipeNameTextBox.Text;
            recipes[recipeIndex].Name = recipeName;
        }

        private void RecipeTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string recipeType = RecipeTypeTextBox.Text;
            recipes[recipeIndex].Type = recipeType;
        }

        private void RecipeDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recipeIndex = RecipeDisplay.SelectedIndex;
            ingredientIndex = -1;
        }

        private void DeleteIngredient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(ingredientIndex != -1 && recipeIndex != -1)
            {
                recipes[recipeIndex].Ingredients.RemoveAt(ingredientIndex);
            }
        }

        private void IngredientSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListView)
            {
                if (ingredientIndex == -1)
                {

                    ListView lv = sender as ListView;

                    ingredientIndex = lv.SelectedIndex;

                    IngredientNameTextBox.Text = recipes[recipeIndex].Ingredients[ingredientIndex].Name;

                    IngredientTypeTextBox.Text = recipes[recipeIndex].Ingredients[ingredientIndex].Type;

                    QuantityTextBox.Text = recipes[recipeIndex].Ingredients[ingredientIndex].QTY.ToString();

                    MeasurementTextBox.Text = recipes[recipeIndex].Ingredients[ingredientIndex].Measurement;

                }
                else
                {
                    ingredientIndex = -1;
                }
            }
        }
    }
}
