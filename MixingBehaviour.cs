using Godot;
using System.Collections.Generic;
using System;

/***
 * Handles the behaviour when two ingredients are chosen
 * @author Lucas_C_Wright
 * @start 1-29-2022
 * @version 2-2-2022
 */
public class MixingBehaviour : Node {
    //private List<Drink> drinkList = new List<Drink>();
    private Dictionary<Tuple<Ingredient, Ingredient>, Drink> drinkMap = new Dictionary<Tuple<Ingredient, Ingredient>, Drink>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        loadList();
    }

    private void loadList() {
        //connect with DrinkData and loop through the DrinkList
            //foreach drink in the drinklist
                //get both ingredients and add them to a tuple
                //add the drink object and tuple object to the drinkMap
    }

    //takes two ingredients from the input system and checks if there's a drink associated with them
    public Drink mixDrink(Ingredient in1, Ingredient in2) {
        //create both versions of the tuple
        Tuple<Ingredient, Ingredient> key1 = new Tuple<Ingredient, Ingredient>(in1, in2);
        Tuple<Ingredient, Ingredient> key2 = new Tuple<Ingredient, Ingredient>(in2, in1);

        //check if either key makes a drink. if a drink is found then return it
        if (drinkMap[key1] != null) {
            return drinkMap[key1];
        } else if (drinkMap[key2] != null) {
            return drinkMap[key2];
        }

        //if no drink is found in the map then return null
        //TODO: null or bad Drink?
        return null;
    }
}
