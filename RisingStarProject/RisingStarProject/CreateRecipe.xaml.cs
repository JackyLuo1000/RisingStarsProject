﻿using RisingStarProject.IngedientModel;
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
        public CreateRecipe()
        {
            this.InitializeComponent();
            RecipeDisplay.ItemsSource = recipes;

        }
       private async void AddIngedient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(IngredientNameTextBox.Text)
                && !string.IsNullOrEmpty(IngredientTypeTextBox.Text)
                && !string.IsNullOrEmpty(QuantityTextBox.Text)
                && !string.IsNullOrEmpty(MeasurementTextBox.Text))
            {
                //Store the fields from text boxes

                string ingredientName = IngredientNameTextBox.Text;

                string type = IngredientTypeTextBox.Text;

                float quantity = float.Parse(QuantityTextBox.Text);

                string measurement = MeasurementTextBox.Text;


                //Create a newIngredient from the fields

                //added instructions 
                Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement };
                // cc

                //In the recipe add the ingredient
                recipes[recipeIndex].Ingredients.Add(newIngredient);

                IngredientNameTextBox.Text = "";
                IngredientTypeTextBox.Text = "";
                QuantityTextBox.Text = "";
                MeasurementTextBox.Text = "";
            }
            else
            {
                await (new MessageDialog("Please enter values to all ingredients fields.")).ShowAsync();
            }

            
            
        }
        private void AddRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //Store information into a new recipe

            recipes.Add(new Recipe());
            recipeIndex = recipes.Count - 1;


            //Add a new recipe to the recipes List
            RecipeNameTextBox.Text = "New Recipe";
            RecipeTypeTextBox.Text = "New Recipe Type";
            InstructionsTextBox.Text = "New Instructions";
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

        private void RecipeInstructionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string recipeInstruction = InstructionsTextBox.Text;
            recipes[recipeIndex].Instructions = recipeInstruction;
        }

        private void RecipeDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recipeIndex = RecipeDisplay.SelectedIndex;
        }
      
    }
}
