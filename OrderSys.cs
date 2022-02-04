using Godot;
using System;

/***
 * Determines which kind of order and which drink is going to be ordered
 * @author Lucas_C_Wright
 * @start 2-2-2022
 * @version 2-3-2022
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
        //whenever this is called generate a new random object so the seed is updated
        Random rand = new Random();

        DrinkData inst = DrinkData.Instance;

        //randomly decide which order type is going to be processed
        int type = rand.Next(0, 2);
        switch (type) { 
        case 0: //if Two Ingredients then...
                //randomly choose a drink from the drink list
                Drink correctDrink = inst.returnDrinkAt(rand.Next(0, inst.DrinkSize() - 1));

                //get both ingredients used in that drink
                Ingredient ing1 = correctDrink.getFirstIng();
                Ingredient ing2 = correctDrink.getSecondIng();

                //send ingredients and correct drink to the communication system
                //TODO
                break;
        case 1: //if One Ingredient then...
                //randomly choose an ingredient from the ingredient list
                Ingredient ing = inst.returnIngredientAt(rand.Next(0, inst.IngredientSize() - 1));

                //send ingredient and list of correct drinks to the communication system
                //TODO
                break;
        case 2: //if Drink then...
                //randomly choose a drink from the drink list
                Drink drink = inst.returnDrinkAt(rand.Next(0, inst.DrinkSize() - 1));

                //send the drink to the communication system
                //TODO
                break;
        default:
                GD.Print("random type number not 0-2: " + type);
                break;
        }
            
                
    }

}
