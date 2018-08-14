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
        private ObservableCollection<Recipe> recipes;
        public CreateRecipe()
        {
            this.InitializeComponent();
            recipes.Add(new Recipe());
        }

        private void Create_Ingredients(object sender, TappedRoutedEventArgs e)
        {
            //Store the fields from text boxes

            string ingredientName = IngredientNameTextBox.Text;

            string type = TypeTextBox.Text;

            float quantity = float.Parse(QuantityTextBox.Text);

            string measurement = MeasurementTextBox.Text;

            //Create a newIngredient from the fields

            Ingredient newIngredient = new Ingredient() { Name = ingredientName, Type = type, QTY = quantity, Measurement = measurement};

            //In the recipe add the ingredient

            recipes.Last().Ingredients.Add(newIngredient);
        }
        private void Create_Recipe(object sender, TappedRoutedEventArgs e)
        {

            //Store information into a new recipe

            string recipeName = RecipeNameTextBox.Text;
            recipes.Last().Name = recipeName;

            //Add a new recipe to the recipes List
            recipes.Add(new Recipe());
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Recipe> && e.Parameter != null)
            {
                recipes = e.Parameter as ObservableCollection<Recipe>;
            }
            base.OnNavigatedTo(e);
        }
    }
}
