using Godot;
using System;

/***
 * Holds information about a singluar ingredient
 * @author Lucas_C_Wright
 * @start 1-31-2022
 * @version 1-31-2022
 */
public class Ingredient {
    private string keyword;

    //default constructor. Shouldn't be used when creating ingredients
    private Ingredient() {
        keyword = "";
    }
    
    //constructor meant to be used
    public Ingredient(string nKeyword) {
        keyword = nKeyword;
    }

    //getter
    public string getKeyword() { return keyword; }
}
