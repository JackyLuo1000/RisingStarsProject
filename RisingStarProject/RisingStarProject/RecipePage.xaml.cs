using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecipePage : Page
    {
        private ObservableCollection<Ingredient> IngredientCollection = new ObservableCollection<Ingredient>();
        private static Recipe currentRecipe = new Recipe();

        public RecipePage()
        {
            this.InitializeComponent();

            IngredientsList.ItemsSource = IngredientCollection;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Recipe)
            {
                Recipe newRecipe = e.Parameter as Recipe;
                currentRecipe = newRecipe;
                Header.Text = newRecipe.Name;
                RecipeType.Text += newRecipe.Type;

                foreach (Ingredient i in currentRecipe.Ingredients)
                {
                    IngredientCollection.Add(i);
                }
            }
            


        }

        private void IngredientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Ingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackToMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage));
        }

        private void Save_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void EditQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IngredientsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ingredient editIngredient = e.ClickedItem as Ingredient;
            //IngredientCollection.Remove(editIngredient);
            EditName.PlaceholderText = editIngredient.Name;
            EditType.PlaceholderText = editIngredient.Type;
            EditQuantity.PlaceholderText = editIngredient.QTY.ToString();
            EditMeasurement.PlaceholderText = editIngredient.Measurement;

        }
    }
}
