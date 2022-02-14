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

        Ingredient firstIng = new Ingredient(GetParent().GetNode<DrinkData>("DrinkData").returnIngredientByKeyword(in1).getKeyword());
        Ingredient secIng = new Ingredient(GetParent().GetNode<DrinkData>("DrinkData").returnIngredientByKeyword(in2).getKeyword());

        GD.Print(firstIng.getKeyword());
        GD.Print(secIng.getKeyword());
        bool res = GetParent().GetNode<OrderSys>("Order System").verifyOrder(firstIng, secIng);


        if (res) {
            GD.Print("Correct");
        } else {
            GD.Print("False");
        }

        GetParent().GetNode<StateMachineRuntime>("State Machine").NextState();
    }
}
