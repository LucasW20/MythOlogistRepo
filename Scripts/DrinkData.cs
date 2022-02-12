using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/***
 * Singleton class that holds a list for Ingredients and Drinks.
 * @author Benjamin_J_Bucheger
 * @start 1-31-2022
 * @version 2-2-2022
 */
public class DrinkData : Node
{
    // Singleton setup
    private static readonly DrinkData _instance = new DrinkData();

    static DrinkData() { }

    private DrinkData() { }

    public static DrinkData Instance {
        get {
            return _instance;
        }
    }

    private List<Ingredient> _ingredientList = new List<Ingredient>();
    private List<Drink> _drinkList = new List<Drink>();


    // Add ingredient to ingredients list
    public void addIngredient(Ingredient ingredient) {
        _ingredientList.Add(ingredient);
    }

    // Loop through ingredient list and return object with matching keyword
    public bool returnIngredient(String keyWord) {
        foreach (Ingredient ingredient in _ingredientList) {
            if (ingredient.getKeyword() == keyWord) {
                return true;
            }
        }
        return false;
    }
    public void addDrink(Drink drink) {
        _drinkList.Add(drink);
    }
    // Loop through drink list and return object with matching keyword
    public Drink returnDrink(string keyWord) {
        foreach (Drink drink in _drinkList) {
            if (drink.getDrinkKeyword() == keyWord) {
                return drink;
            }
        }
        return null;
    }

    //get a drink via index
    public Drink returnDrinkAt(int index) { return _drinkList[index]; }
    //get an ingredient via index
    public Ingredient returnIngredientAt(int index) { return _ingredientList[index]; }
    //get size of ingredient list
    public int IngredientSize() { return _ingredientList.Count; }
    //get size of drink list
    public int DrinkSize() { return _drinkList.Count; }



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // add all drink and ingredients to list

        // Adds ingredients to _ingredientList from IngredientsList text file
        var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\IngredientsList.txt"); // open new path to file
        List<string> text = System.IO.File.ReadLines(path).ToList(); // read file into temporary List
        
        // Read through List and use string to make new Ingredient objects
        // and load objects into _ingredientList
        foreach (string txt in text) {
            Ingredient tempIng = new Ingredient(txt+".png");
            _ingredientList.Add(tempIng);
        }

        // Adds Drinks to _drinkList from DrinkList text file
        path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\DrinksList.txt"); // change path
        text = System.IO.File.ReadLines(path).ToList();
        
        // Read through List and use string to make new Drink objects
        // and load objects into _drinkList
        string[] temp;
        foreach (string txt in text) {
            temp = txt.Split(','); // split text list elements into an array

            // If both ingredients are found in the ingredients list, create a new drink using those ingredients
            if (returnIngredient(temp[1]+".png") && returnIngredient(temp[2]+".png")) {
                Ingredient tempIng1 = new Ingredient(temp[1]+".png");
                Ingredient tempIng2 = new Ingredient(temp[2]+".png");
                
                Drink tempDrink = new Drink((temp[0]+".png"), tempIng1, tempIng2);

                GD.Print(tempDrink.getFirstIng().getKeyword());
                _drinkList.Add(tempDrink);
            }
        }
    }
}
