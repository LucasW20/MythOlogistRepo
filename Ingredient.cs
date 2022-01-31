using Godot;
using System;

/***
 * Holds information about a singluar ingredient
 * @author Lucas_C_Wright
 * @start 1-31-2022
 * @version 1-31-2022
 */
public class Ingredient {
    private string name;
    private string keyword;

    //default constructor. shouldnt be used when creating ingredients
    private Ingredient() {
        name = "";
        keyword = "";
    }
    
    //constructor meant to be used
    public Ingredient(string nName, string nKeyword) {
        name = nName;
        keyword = nKeyword;
    }

    //getters
    public string getName() { return name; }
    public string getKeyword() { return keyword; }
}
