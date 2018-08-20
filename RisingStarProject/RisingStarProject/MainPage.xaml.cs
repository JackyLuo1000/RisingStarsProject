using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
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
        private static string SearchInput;
        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        ObservableCollection<Recipe> displayRecipes = new ObservableCollection<Recipe>();
        public event PropertyChangedEventHandler PropertyChanged;
        MessageDialog showDialog;

        public MainPage()
        {
            this.InitializeComponent();

            lbxDisplay.ItemsSource = displayRecipes;

            Ingredient I1 = new Ingredient();
            I1.Name = "Diced Tomatoes";
            I1.Type = "Fruit";
            I1.QTY = 1;
            I1.Measurement = "Cup";

            Ingredient I2 = new Ingredient();
            I2.Name = "Sliced Jalapenos";
            I2.Type = "Fruit";
            I2.QTY = 0.5f;
            I2.Measurement = "Cup";

            Ingredient I3 = new Ingredient();
            I3.Name = "Roasted Diced Tomatillo";
            I3.Type = "Fruit";
            I3.QTY = 0.25f;
            I3.Measurement = "Cup";

            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>()
            {
                I1, I2, I3
            };

            recipes.Add(new Recipe { Name = "Ramen", Type = "Main Dish", Ingredients = ingredients });
            recipes.Add(new Recipe { Name = "Pot Roast", Type = "Main Dish", Ingredients = ingredients });
            foreach(Recipe r in recipes)
            {
                displayRecipes.Add(r);
            }
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

        private void OpenRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //This is a test recipe
            Ingredient I1 = new Ingredient();
            I1.Name = "Diced Tomatoes";
            I1.Type = "Fruit";
            I1.QTY = 1;
            I1.Measurement = "Cup";

            Ingredient I2 = new Ingredient();
            I2.Name = "Sliced Jalapenos";
            I2.Type = "Vegetable";
            I2.QTY = 0.5f;
            I2.Measurement = "Cup";

            Ingredient I3 = new Ingredient();
            I3.Name = "Basil";
            I3.Type = "Seasoning";
            I3.QTY = 0.25f;
            I3.Measurement = "Cup";

            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>()
            {
                I1, I2, I3
            };

            Recipe SelectedRecipe = new Recipe();
            SelectedRecipe.Name = "Oven Baked Chicken";
            SelectedRecipe.Type = "Main Dish";
            SelectedRecipe.Ingredients = ingredients;

            //Add logic for setting SelectedRecipe to the currently selected recipe

            this.Frame.Navigate(typeof(RecipePage), SelectedRecipe);
        }

        //Search Filter.
        private void Name_Search()
        {
            Regex reg = new Regex($"^{SearchInput}?.+");
            if (!reg.IsMatch(SearchInput))
            {
                showDialog = new MessageDialog("Please enter a search field.");
            }
            else
            {
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    if (reg.IsMatch(r.Name))
                    {
                        displayRecipes.Add(r);
                    }
                }
            }
        }

        //Search Filter.
        private void Ingredient_Search()
        {
            
        }

        //Search Filter.
        private void Type_Search()
        {
            
        }

        //Search Button Click.
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (cbxList.SelectedValue.ToString() == "Name")
            {
                Name_Search();
            }
            else if (cbxList.SelectedValue.ToString() == "Type")
            {
                Type_Search();
            }
            else if (cbxList.SelectedValue.ToString() == "Ingredient")
            {
                Ingredient_Search();
            }
        }

        //TextBox Search-bar.
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchInput = tbxSearch.Text;
        }

        void OnPropertyChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
