using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

                Instructions.Text = currentRecipe.Instructions;
            }



        }
        
        private void BackToMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage), currentRecipe);
        }

        private void Save_Tapped(object sender, TappedRoutedEventArgs e)
        {
            currentRecipe.Ingredients.Clear();

            foreach (Ingredient i in IngredientCollection)
            {
                currentRecipe.Ingredients.Add(i);
            }

            this.Frame.Navigate(typeof(MainPage), currentRecipe);
        }

        private void IngredientsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Ingredient editIngredient = e.ClickedItem as Ingredient;
            EditName.Text = "";
            EditType.Text = "";
            EditQuantity.Text = "";
            EditMeasurement.Text = "";

            EditName.PlaceholderText = editIngredient.Name;
            EditType.PlaceholderText = editIngredient.Type;
            EditQuantity.PlaceholderText = editIngredient.QTY.ToString();
            EditMeasurement.PlaceholderText = editIngredient.Measurement;
        }

        private async void UpdateIngredient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IngredientsList.SelectedIndex >= 0 && IngredientsList.SelectedIndex < IngredientCollection.Count)
            {
                int index = IngredientsList.SelectedIndex;

                if (!string.IsNullOrEmpty(EditName.Text))
                {
                    IngredientCollection[index].Name = EditName.Text;
                }

                if (!string.IsNullOrEmpty(EditType.Text))
                {
                    IngredientCollection[index].Type = EditType.Text;
                }

                if (!string.IsNullOrEmpty(EditQuantity.Text))
                {
                    IngredientCollection[index].QTY = float.Parse(EditQuantity.Text);
                }

                if (!string.IsNullOrEmpty(EditMeasurement.Text))
                {
                    IngredientCollection[index].Measurement = EditMeasurement.Text;
                }
                EditName.PlaceholderText = IngredientCollection[index].Name;
                EditType.PlaceholderText = IngredientCollection[index].Type;
                EditQuantity.PlaceholderText = IngredientCollection[index].QTY.ToString();
                EditMeasurement.PlaceholderText = IngredientCollection[index].Measurement;
                EditName.Text = "";
                EditType.Text = "";
                EditQuantity.Text = "";
                EditMeasurement.Text = "";
                IngredientsList.SelectedIndex = -1;
            }
            else
            {
                await (new MessageDialog("Please select an ingredient to update.")).ShowAsync();
            }

        }

        private void DeleteRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void AddIngredient_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Ingredient newIngredient = new Ingredient();
            if (!string.IsNullOrEmpty(EditName.Text))
            {
                newIngredient.Name = EditName.Text;
            }
            else
            {
                newIngredient.Name = "Empty";
            }

            if (!string.IsNullOrEmpty(EditType.Text))
            {
                newIngredient.Type = EditType.Text;
            }
            else
            {
                newIngredient.Type = "Empty";
            }

            if (!string.IsNullOrEmpty(EditQuantity.Text))
            {
                newIngredient.QTY = float.Parse(EditQuantity.Text);
            }
            else
            {
                newIngredient.QTY = 0;
            }

            if (!string.IsNullOrEmpty(EditMeasurement.Text))
            {
                newIngredient.Measurement = EditMeasurement.Text;
            }
            else
            {
                newIngredient.Measurement = "Empty";
            }

            EditName.Text = "";
            EditType.Text = "";
            EditQuantity.Text = "";
            EditMeasurement.Text = "";

            IngredientCollection.Add(newIngredient);
            IngredientsList.SelectedIndex = -1;
        }

        private void Intructions_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentRecipe.Instructions = Instructions.Text;
        }
    }
}
