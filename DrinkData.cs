using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

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


    public void addIngredient(Ingredient ingredient) {
        _ingredientList.Add(ingredient);
    }

    // Loop through ingredient list and return object with matching keyword
    public Ingredient returnIngredient(String keyWord) {
        foreach (Ingredient ingredient in _ingredientList) {
            if (ingredient.getKeyword() == keyWord) {
                return ingredient;
            }
        }
        return null;
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

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // add all drink and ingredients to list
        //var path = Path.Combine(Directory.GetCurrentDireectory(), "\\ingredientsList.txt");

        // REQUIRES TESTING AS IS
        // Other errors preventing from checking if filling the list works

        var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\IngredientsList.txt");
        List<string> text = System.IO.File.ReadLines(path).ToList();
        GD.Print("Text list count: " + text.Count());
        foreach (string txt in text) {
            Ingredient tempIng = new Ingredient(txt+"png");
            _ingredientList.Add(tempIng);
        }
        GD.Print("Ingredient list count: " + _ingredientList.Count());

        path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\DrinksList.txt");
        text = System.IO.File.ReadLines(path).ToList();
        GD.Print("Text list count: " + text.Count());
        string[] temp;
        foreach (string txt in text) {
            temp = txt.Split(',');
            Ingredient tempIng1 = new Ingredient(txt[1]+"png"); // first ingredient
            Ingredient tempIng2 = new Ingredient(txt[2]+"png"); // second ingredient
            Drink tempDrink = new Drink(text[0]+"png", tempIng1, tempIng2);
            _drinkList.Add(tempDrink);
        }
        GD.Print("Drink list count: " + _drinkList.Count());
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
