using Godot;
using System;

/***
 * Grabs the input variables from GDScripts and converts them into objects that the C# scripts use
 * @author Lucas_C_Wright
 * @start 2-13-2022
 * @version 2-13-2022
 */
public class ParseInput : Node {

    //takes two strings of keywords for ingredients from GDScripts and converts them into C# objects
    public void Parse(string in1, string in2) {
        //testing input
        //GD.Print("C#: " + in1);
        //GD.Print("C#: " + in2);

        Ingredient firstIng = GetParent().GetNode<DrinkData>("DrinkData").returnIngredientByKeyword(in1);
        Ingredient secIng = GetParent().GetNode<DrinkData>("DrinkData").returnIngredientByKeyword(in2);

        //bool res = GetParent().GetNode<OrderSys>("Order System").verifyOrder(firstIng, secIng);

        if (true) {
            GetParent().GetNode<StateMachineRuntime>("State Machine").NextState();
        }
    }
}
