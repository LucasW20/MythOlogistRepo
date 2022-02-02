using Godot;
using System;

/***
 * Determines which kind of order and which drink is going to be ordered
 * @author Lucas_C_Wright
 * @start 2-2-2022
 * @version 2-2-2022
 */
public class OrderSys : Node {



    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta) {
//      
//  }

    
    /***
     * Order Types:
     * Two Ingredients ordered
     * One Ingredient ordered
     * Drink ordered
     */
    public void Order() {
        //randomly decide which order type is going to be processed
            //if Two Ingredients then...
                //randomly choose a drink from the drink list
                //get both ingredients used in that drink
                //send ingredients and correct drink to the communication system
            //if One Ingredient then...
                //randomly choose an ingredient from the ingredient list
                //send ingredient and list of correct drinks to the communication system
            //if Drink then...
                //randomly choose a drink from the drink list
                //send the drink to the communication system
    }

}
