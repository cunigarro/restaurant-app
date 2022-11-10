using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
{
    public class Recipe
    {
        private int idRecipe;
        private int idIngredient;
        private int idMeasure;
        private string description;

        private string commandString;

        public string requestAllRecipes()
        {
            return @"SELECT * FROM Recipe";
        }

        public void setIdRecipe(int value)
        {
            this.idRecipe = value;
        }

        public void setIdIngredient(int value)
        {
            this.idIngredient = value;
        }

        public void setIdMeasure(int value)
        {
            this.idMeasure = value;
        }

        public void setDescription(string value)
        {
            this.description = value;
        }

        public void addRecipe()
        {
            string queryString;
            queryString = @"INSERT INTO Recipe(ID_Recipe, ID_Ingredient, ID_Measure, Description) VALUES(" + this.idRecipe + ", " + this.idIngredient + ", " + this.idMeasure + ", '" + this.description + "')";
            commandString = queryString;
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
