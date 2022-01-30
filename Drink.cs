using Godot;
using System;

/***
 * Holds information about a single drink
 * @atuhor Lucas_C_Wright
 * @start 1-29-2022
 * @version 1-29-2022
 */
public class Drink{
	private string ingredient1;
	private string ingredient2;
	private string keyword;

	//constructor to be used when creating a new drink and recipe.
	public Drink(string nIng1, string nIng2, string nKW) {
		//assigned passed values to class variables
		ingredient1 = nIng1;
		ingredient2 = nIng2;
		keyword = nKW;
	}

	//default constructor. Should never be used to avoid blank receipes and errors
	private Drink() {
		ingredient1 = "";
		ingredient2 = "";
		keyword = "";
	}

	//getters
	public string[] getIngredientsArray() {
		string[] ings = new string[2];
		ings[0] = ingredient1;
		ings[1] = ingredient2;

		return ings;
	}
	public string getDrinkKeyword() { return keyword; }
	public string getFirstIng() { return ingredient1; }
	public string getSecondIng() { return ingredient2; }
}
