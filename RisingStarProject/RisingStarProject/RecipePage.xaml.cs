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
            Recipe newRecipe = e.Parameter as Recipe;
            currentRecipe = newRecipe;
            if (newRecipe != null)
            {
                Header.Text = newRecipe.Name;
                RecipeType.Text += newRecipe.Type; 

                foreach(Ingredient i in currentRecipe.Ingredients)
                {
                    IngredientCollection.Add(i);
                }
            }

            
        }

        private void IngredientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
