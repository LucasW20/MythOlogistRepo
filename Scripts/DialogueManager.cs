using Godot;
using System;
using System.Collections.Generic;

/***
 * Manages speech popup to communicate orders to player.
 * @author Benjamin_J_Bucheger
 * @start 1-30-2022
 * @version 1-31-2022
 */
public class DialogueManager : Control
{
	public Drink drink_list;
	[Export]
	public PackedScene InteraceSelectableObject;

	// TEST VARIABLES
	
//    private String ingredient_01 = "in_01_realGreekFire.png";
//    private String ingredient_02 = "in_02_unicornHorn.png";
//    private String drink = "dr_01_crunchy.png";
//    private String orderType = "drink"; // shows both ingredients
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// test case
		//ShowDialogueElement(ingredient_01, ingredient_02, drink, orderType);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	// TEST CASE
	// Shows popup with ingredients as parameters
	public void ShowDialogueElement(String ingredient_01, String ingredient_02, String drink, String orderType) {
		// make popup visible
		GetNode<Popup>("Popup").Popup_();

		// check order type for how to display drinks
		switch(orderType)
		{
			case ("ingredient"): // shows both ingredients
				// change both ingredient sprites to match ingredients
				GetNode<Sprite>("Popup/Ingredient01").Texture = ResourceLoader.Load("res://Images/Ingredients/"+ingredient_01) as Texture;
				GetNode<Sprite>("Popup/Ingredient02").Texture = ResourceLoader.Load("res://Images/Ingredients/"+ingredient_02) as Texture;

				// make ingredient sprites and label visible
				GetNode<Sprite>("Popup/Ingredient01").Visible = true;
				GetNode<Sprite>("Popup/Ingredient02").Visible = true;
				GetNode<Label>("Popup/PlusSign").Visible = true;

				break;
			case ("vague"): // shows one ingredient and a question mark
				// change first ingredient sprite to match ingredient
				// TODO - select shown ingredient at random
				GetNode<Sprite>("Popup/Ingredient01").Texture = ResourceLoader.Load("res://Images/Ingredients/"+ingredient_01) as Texture;

				// make first ingredient sprite and label visible
				GetNode<Sprite>("Popup/Ingredient01").Visible = true;
				GetNode<Label>("Popup/PlusSign").Visible = true;

				break;
			case ("drink"): // shows completed drink
				// change drink sprite to match drink
				GetNode<Sprite>("Popup/Drink").Texture = ResourceLoader.Load("res://Images/Drinks/"+drink) as Texture;

				// make drink sprite visible
				GetNode<Sprite>("Popup/Drink").Visible = true;

				break;
		}
	}

	// shows popup with drink as parameter
	public void ShowDialogueElement(Drink drink, String orderType) {
		// make popup visible
		GetNode<Popup>("Popup").Popup_();

		// check order type for how to display drinks
		switch(orderType)
		{
			case ("ingredient"): // shows both ingredients
				// change both ingredient sprites to match ingredients
				GetNode<Sprite>("Popup/Ingredient01").Texture = ResourceLoader.Load("res://Images/Ingredients/"+drink.getFirstIng().getKeyword()) as Texture;
				GetNode<Sprite>("Popup/Ingredient02").Texture = ResourceLoader.Load("res://Images/Ingredients/"+drink.getSecondIng().getKeyword()) as Texture;

				// make ingredient sprites and label visible
				GetNode<Sprite>("Popup/Ingredient01").Visible = true;
				GetNode<Sprite>("Popup/Ingredient02").Visible = true;
				GetNode<Label>("Popup/PlusSign").Visible = true;

				break;
			case ("vague"): // shows one ingredient and a question mark
				// change first ingredient sprite to match ingredient

				// TODO - select shown ingredient at random
				GetNode<Sprite>("Popup/Ingredient01").Texture = ResourceLoader.Load("res://Images/Ingredients/"+drink.getFirstIng().getKeyword()) as Texture;

				// make first ingredient sprite and label visible
				GetNode<Sprite>("Popup/Ingredient01").Visible = true;
				GetNode<Label>("Popup/PlusSign").Visible = true;

				break;
			case ("drink"): // shows completed drink
				// change drink sprite to match drink
				GetNode<Sprite>("Popup/Drink").Texture = ResourceLoader.Load("res://Images/Drinks/"+drink.getDrinkKeyword()) as Texture;

				// make drink sprite visible
				GetNode<Sprite>("Popup/Drink").Visible = true;

				break;
		}
	}
}
