using Godot;
using System;

/***
 * Determines which kind of order and which drink is going to be ordered
 * @author Lucas_C_Wright
 * @start 2-2-2022
 * @version 2-12-2022
 */
public class OrderSys : Node {
	private DialogueManager speech;
	private MixingBehaviour mix;
	private Drink correctDrink;
	private DrinkData inst;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		inst = GetParent().GetNode<DrinkData>("DrinkData");
		speech = GetParent<Node2D>().GetNode<InterfaceManager>("InterfaceManager").GetNode<DialogueManager>("DialogueManager");
		mix = GetParent().GetNode<MixingBehaviour>("Mixing");
		correctDrink = null;

		//GD.Print("Ran OrderSys");
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta) {
	//      
	//  }

	//when called this method creates a random order type and drink being ordered
	public void Order() {
		//whenever this is called generate a new random object so the seed is updated
		Random rand = new Random();
		string ordType;

		//randomly decide which order type is going to be processed
		int type = rand.Next(0, 2);
		switch (type) {
			case 0:
				ordType = "ingredient";
				break;
			case 1:
				ordType = "vague";
				break;
			case 2:
				ordType = "drink";
				break;
			default:
				GD.Print("random type number not 0-2: " + type);
				ordType = "ingredient";
				break;
		}

		//get a random drink & update the class's correct drink
		int index = rand.Next(0, inst.DrinkSize() - 1);
		//GD.Print("Random Index for Order System: " + index);
		//GD.Print("DrinkList Size: " + inst.DrinkSize());
		Drink randDr = inst.returnDrinkAt(index);
		correctDrink = randDr;

		//randDr.printDrinkToConsole();

		//communicate the correct drink and the type to the speech system
		speech.ShowDialogueElement(randDr, ordType);
	}

	//takes in two ingredients from the input system and checks if it matches the correct drink
	public bool verifyOrder(Ingredient in1, Ingredient in2) {
		Drink mixedDrink = mix.mixDrink(in1, in2); //mix the drinks

		//check if the mixed drink matches the classes correct drink
		if (mixedDrink != null && mixedDrink == correctDrink) {
			correctDrink = null;
			return true;
		}

		//if mixedDrink is null or they don't match then return false
		return false;
	}


	/*
   Create order:
	  Make random drink instance
	  Make random OrderType (drink, ingredient, vague) This only effects how info is displayed

	  Pass drink and Ordertype into DialogueManager through showDialogue() function (again this only effects ho info is displayed)

	  Take player input: Will always be 2 ingredients
	  Compare ingredients to order by checking drink.getIng() functions

	  If correct mix:
		  Win statement
	  Else:
		  Try again, or failure statement
   */
}
