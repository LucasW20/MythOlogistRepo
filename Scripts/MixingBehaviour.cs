using Godot;
using System.Collections.Generic;
using System;

/***
 * Handles the behavior when two ingredients are chosen
 * @author Lucas_C_Wright
 * @start 1-29-2022
 * @version 2-13-2022
 */
public class MixingBehaviour : Node {
    //private List<Drink> drinkList = new List<Drink>();
    //private Dictionary<Tuple<Ingredient, Ingredient>, Drink> drinkMap = new Dictionary<Tuple<Ingredient, Ingredient>, Drink>();
    private DrinkData inst;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        //GD.Print("Started MixingBehaviour");
        inst = GetParent().GetNode<DrinkData>("DrinkData");
    }

    //private void loadList() {
    //    //connect with DrinkData and loop through the DrinkList
    //    DrinkData inst = GetParent().GetNode<DrinkData>("DrinkData");

    //    /*
    //    //foreach drink in the drinklist
    //    for (int i = 0; i < inst.DrinkSize(); i++) {
    //        //add the drink object and tuple object to the drinkMap
    //        drinkMap.Add(new Tuple<Ingredient, Ingredient>(inst.returnDrinkAt(i).getFirstIng(), inst.returnDrinkAt(i).getSecondIng()),
    //            inst.returnDrinkAt(i));
    //    }
    //    */
    //}

    //takes two ingredients from the input system and checks if there's a drink associated with them
    public Drink mixDrink(Ingredient in1, Ingredient in2) {
        for (int i = 0; i < inst.DrinkSize(); i++) {
            //check first order in1 & in2
            if (inst.returnDrinkAt(i).getFirstIng().getKeyword() == in1.getKeyword() && inst.returnDrinkAt(i).getSecondIng().getKeyword() == in2.getKeyword()) {
                //return good
                GetParent().GetParent().GetNode<Sprite>("glass").Texture = ResourceLoader.Load("res://Images/Drinks/" + inst.returnDrinkAt(i).getDrinkKeyword()) as Texture;
                return inst.returnDrinkAt(i);
            } else if (inst.returnDrinkAt(i).getFirstIng().getKeyword() == in2.getKeyword() && inst.returnDrinkAt(i).getSecondIng().getKeyword() == in1.getKeyword()) { //check second order in2 & in1
                //return good
                GetParent().GetParent().GetNode<Sprite>("glass").Texture = ResourceLoader.Load("res://Images/Drinks/" + inst.returnDrinkAt(i).getDrinkKeyword()) as Texture;
                return inst.returnDrinkAt(i);
            }
        }

        /*
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
        
        */
        return null;
    }
}
