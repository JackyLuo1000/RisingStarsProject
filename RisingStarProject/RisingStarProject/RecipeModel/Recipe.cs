using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace RisingStarProject.RecipeModel
{
  class Program
    {
        [ProtoContract]
        public class Recipe : INotifyPropertyChanged
        {
            [ProtoIgnore]
            private string name;
            [ProtoIgnore]
            private string type;
            [ProtoIgnore]
            private string instructions;
            [ProtoMember(1)]
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    FieldChanged();
                }
            }
            [ProtoMember(2)]
            public string Type
            {
                get { return type; }
                set
                {
                    type = value;
                    FieldChanged();
                }
            }
            [ProtoMember(3)]
            public ObservableCollection<Ingredient> Ingredients { get; set; }
            [ProtoMember(4)]
            public string Instructions
            {
                get { return instructions; }
                set
                {
                    instructions = value;
                    FieldChanged();
                }
            }

            public Recipe()
            {
                Name = "Recipe";
                Type = "Type";
                Ingredients = new ObservableCollection<Ingredient>();
                Instructions = "";
            }

            public Recipe(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public override string ToString()
            {

                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Name))
                {
                    sb.AppendLine($"Recipe Name: {Name}");
                }
                if (!string.IsNullOrEmpty(Type))
                {
                    sb.AppendLine($"Recipe Type: {Name}");
                }
                if (Ingredients != null && Ingredients.Count() != 0)
                {
                    foreach(Ingredient i in Ingredients)
                    {
                        sb.AppendLine( i.ToString() );
                    }
                }
                return sb.ToString();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void FieldChanged([CallerMemberName]string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
