using Godot;
using System;

/***
 * Holds information about a single drink
 * @author Lucas_C_Wright
 * @start 1-29-2022
 * @version 2-4-2022
 */
public class Drink {
	private Ingredient ing1;
	private Ingredient ing2;
	private string keyword;

	//constructor to be used when creating a new drink and recipe.
	public Drink(string nKeyword, Ingredient nIng1, Ingredient nIng2) {
		keyword = nKeyword;
		ing1 = nIng1;
		ing2 = nIng2;
    }

	//default constructor. Should never be used to avoid blank recipes and errors
	private Drink() {
		ing1 = null;
		ing2 = null;
		keyword = "";
	}

	//getters
	public Ingredient[] getIngredientsArray() {
		Ingredient[] ings = new Ingredient[2];
		ings[0] = ing1;
		ings[1] = ing2;

		return ings;
	}
	public string getDrinkKeyword() { return keyword; }
	public Ingredient getFirstIng() { return ing1; }
	public Ingredient getSecondIng() { return ing2; }
}
