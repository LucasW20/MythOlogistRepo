using Godot;
using System;
using System.Collections.Generic;

public class DrinkData : Node
{
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
    public void returnIngredient(Ingredient ingredient) {

    }
    public void addDrink(Drink drink) {
        _drinkList.Add(drink);
    }
    public void returnDrink(Drink drink) {
        
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
