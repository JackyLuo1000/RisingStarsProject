using ProtoBuf;
using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.Storage;
using Windows.Storage.Pickers;
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
        public static ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private static string SearchInput;
        ObservableCollection<Recipe> displayRecipes = new ObservableCollection<Recipe>();
        public event PropertyChangedEventHandler PropertyChanged;
        string mruToken = "";

        public MainPage()
        {
            this.InitializeComponent();

            lbxDisplay.ItemsSource = displayRecipes;

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
                if (oldRecipes.Count != 0)
                {
                    recipes.Clear();
                    displayRecipes.Clear();
                    foreach (Recipe r in oldRecipes)
                    {
                        recipes.Add(r);
                        displayRecipes.Add(r);
                    }
                }
            }
            if (e.Parameter is Recipe && e.Parameter != null)
            {
                Recipe newRecipe = e.Parameter as Recipe;
                recipes.Add(newRecipe);
                displayRecipes.Add(newRecipe);
            }
            base.OnNavigatedTo(e);
        }

        //Search Filter.
        private async void Name_Search()
        {
            try
            {
                Regex reg = new Regex($"{SearchInput}");
                if (!reg.IsMatch(SearchInput))
                {
                    await(new MessageDialog("No Match.")).ShowAsync();
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
            catch (Exception X)
            {
                //await (new MessageDialog("Please enter a search field.")).ShowAsync();
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    displayRecipes.Add(r);
                }
            }
        }

        //Search Filter.
        private async void Ingredient_Search()
        {
            try
            {
                Regex reg = new Regex($"{SearchInput}");
                if (!reg.IsMatch(SearchInput))
                {
                    await(new MessageDialog("No Match.")).ShowAsync();
                }
                else
                {
                    displayRecipes.Clear();
                    foreach (Recipe r in recipes)
                        foreach (var i in r.Ingredients)
                        {
                            if (reg.IsMatch(i.Name) || reg.IsMatch(i.Type))
                            {
                                displayRecipes.Add(r);
                                break;
                            }
                        }
                }
            }
            catch (Exception X)
            {
                //await (new MessageDialog("Please enter a search field.")).ShowAsync();
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                    foreach (var i in r.Ingredients)
                    {
                        displayRecipes.Add(r);
                        break;
                    }
            }
        }

        //Search Filter.
        private async void Type_Search()
        {
            try
            {
                Regex reg = new Regex($"{SearchInput}");
                if (!reg.IsMatch(SearchInput))
                {
                    await(new MessageDialog("No Match.")).ShowAsync();
                }
                else
                {
                    displayRecipes.Clear();
                    foreach (Recipe r in recipes)
                    {
                        if (reg.IsMatch(r.Type))
                        {
                            displayRecipes.Add(r);
                        }
                    }
                }
            }
            catch (Exception X)
            {
                //await (new MessageDialog("Please enter a search field.")).ShowAsync();
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    displayRecipes.Add(r);
                }
            }
        }

        //Search Button Click.
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception X)
            {
                //await(new MessageDialog("Please select a search-filter.")).ShowAsync();
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    displayRecipes.Add(r);
                }
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

        //Saves the all the recipes as a binary serialized .recipes file
        private async void Save_Recipes(object sender, RoutedEventArgs e)
        {
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.FileTypeChoices.Add("Recipes", new List<string>() { ".recipes" });
            fileSavePicker.SuggestedFileName = "New Recipes";
            StorageFile file = await fileSavePicker.PickSaveFileAsync();
            if (file != null)
            {
                using (Stream fs = await file.OpenStreamForWriteAsync())
                {
                    fs.SetLength(0);
                    CachedFileManager.DeferUpdates(file);
                    Serializer.Serialize(fs, recipes);
                }
            }
        }

        //Clears recipes then loads all recipes from a binary serialized .recipes file
        private async void Load_Recipes(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".recipes");
            StorageFile file = await fileOpenPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (Stream fs = await file.OpenStreamForReadAsync())
                {
                    recipes.Clear();
                    displayRecipes.Clear();
                    foreach (Recipe recipe in Serializer.Deserialize<ObservableCollection<Recipe>>(fs))
                    {
                        recipes.Add(recipe);
                        displayRecipes.Add(recipe);
                    }
                }
            }
        }

        private async void Add_Grocery(object sender, RoutedEventArgs e)
        {
            if (lbxDisplay.SelectedIndex >= 0 && lbxDisplay.SelectedIndex < displayRecipes.Count)
            {
                var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;
                if (mruToken != null && mruToken != "")
                {
                    StorageFile file = await mru.GetFileAsync(mruToken);
                    string text = "";
                    if (file != null)
                    {
                        using (Stream fs = await file.OpenStreamForReadAsync())
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                text = await sr.ReadToEndAsync();
                            }
                        }
                        using (Stream fs = await file.OpenStreamForWriteAsync())
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                await sw.WriteAsync(text);
                                await sw.WriteLineAsync($"{displayRecipes[lbxDisplay.SelectedIndex].Name}");
                                foreach (Ingredient i in displayRecipes[lbxDisplay.SelectedIndex].Ingredients)
                                {
                                    await sw.WriteLineAsync($"{i.Name}: {i.QTY} {i.Measurement}");
                                }
                                await sw.WriteLineAsync();
                            }
                        }
                    }
                }
                else
                {
                    FileSavePicker fileSavePicker = new FileSavePicker();
                    fileSavePicker.FileTypeChoices.Add("Text", new List<string>() { ".txt" });
                    fileSavePicker.SuggestedFileName = "Grocery List";
                    StorageFile file = await fileSavePicker.PickSaveFileAsync();
                    if (file != null)
                    {
                        using (Stream fs = await file.OpenStreamForWriteAsync())
                        {
                            fs.SetLength(0);
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                await sw.WriteLineAsync($"{displayRecipes[lbxDisplay.SelectedIndex].Name}");
                                foreach (Ingredient i in displayRecipes[lbxDisplay.SelectedIndex].Ingredients)
                                {
                                    await sw.WriteLineAsync($"{i.Name}: {i.QTY} {i.Measurement}");
                                }
                                await sw.WriteLineAsync();
                                mruToken = mru.Add(file, "grocery");
                            }
                        }
                    }
                }
            }
            else
            {
                await (new MessageDialog("Please select a recipe to add to grocery list.")).ShowAsync();
            }
        }

        private async void Delete_Recipe(object sender, RoutedEventArgs e)
        {
            if (lbxDisplay.SelectedIndex >= 0 && lbxDisplay.SelectedIndex < displayRecipes.Count)
            {
                Recipe r = displayRecipes[lbxDisplay.SelectedIndex];
                displayRecipes.Remove(r);
                recipes.Remove(r);
            }
            else
            {
                await (new MessageDialog("Please select a recipe to delete.")).ShowAsync();
            }
        }

        private void lbxDisplay_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recipe SelectedRecipe = e.ClickedItem as Recipe;
            this.Frame.Navigate(typeof(RecipePage), SelectedRecipe);
            recipes.Remove(SelectedRecipe);
        }
    }
}
