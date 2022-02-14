using Godot;
using System;

/***
 * Holds information about a singluar ingredient
 * @author Lucas_C_Wright
 * @start 1-31-2022
 * @version 2-4-2022
 */
public class Ingredient {
    private string keyword;

    //constructors
    private Ingredient() { keyword = ""; } //Shouldn't be used when creating ingredients
    public Ingredient(string nKeyword) { keyword = nKeyword; } //Should be used when creating ingredients

    //getter
    public string getKeyword() { return keyword; }

    public bool Equals(Ingredient other)
    {
        if (this.keyword == other.getKeyword())
        {
            return true;
        }
        return false;
    }

    public static bool operator ==(Ingredient ingredient1, Ingredient ingredient2)
    {
        return ingredient1.Equals(ingredient2);
    }

    public static bool operator !=(Ingredient ingredient1, Ingredient ingredient2)
    {
        return !ingredient1.Equals(ingredient2);
    }
}