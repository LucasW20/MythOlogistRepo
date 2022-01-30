using Godot;
using System.Collections.Generic;

/***
 * Handles the behaviour when two ingredients are chosen
 * @author Lucas_C_Wright
 * @start 1-29-2022
 * @version 1-29-2022
 */
public class MixingBehaviour : Node {
    private List<Drink> drinkList = new List<Drink>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        loadList();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta) {
//      
//  }

    //called by the order system to determine which drink is being made. returns the keyword (string) of the drink 
    public string mixDrink(string ingredient1, string ingredient2) {
        //loop through the drinkList to match the ingredients
        for (int i = 0; i < drinkList.Count; ++i) {
            //if either order of ingredients matches one of the drinks then return the keyword of that drink
            if (drinkList[i].getFirstIng() == ingredient1 && drinkList[i].getSecondIng() == ingredient2) {
                return drinkList[i].getDrinkKeyword();
            }
            else if (drinkList[i].getFirstIng() == ingredient2 && drinkList[i].getSecondIng() == ingredient1) {
                return drinkList[i].getDrinkKeyword();
            }
        }
        
        //if no match is found then return a blank string
        return "";
    }

    //create each drink and add it to the list
    private void loadList() {
        Drink dr1 = new Drink("", "", "dr_01_name");
        drinkList.Add(dr1);
        Drink dr2 = new Drink("", "", "dr_02_name");
        drinkList.Add(dr2);
        Drink dr3 = new Drink("", "", "dr_03_name");
        drinkList.Add(dr3);
        Drink dr4 = new Drink("", "", "dr_04_name");
        drinkList.Add(dr4);
        Drink dr5 = new Drink("", "", "dr_05_name");
        drinkList.Add(dr5);
        Drink dr6 = new Drink("", "", "dr_06_name");
        drinkList.Add(dr6);
        Drink dr7 = new Drink("", "", "dr_07_name");
        drinkList.Add(dr7);
        Drink dr8 = new Drink("", "", "dr_08_name");
        drinkList.Add(dr8);
        Drink dr9 = new Drink("", "", "dr_09_name");
        drinkList.Add(dr9);
        Drink dr10 = new Drink("", "", "dr_10_name");
        drinkList.Add(dr10);
        Drink dr11 = new Drink("", "", "dr_11_name");
        drinkList.Add(dr11);
        Drink dr12 = new Drink("", "", "dr_12_name");
        drinkList.Add(dr12);
        Drink dr13 = new Drink("", "", "dr_13_name");
        drinkList.Add(dr13);
        Drink dr14 = new Drink("", "", "dr_14_name");
        drinkList.Add(dr14);
        Drink dr15 = new Drink("", "", "dr_15_name");
        drinkList.Add(dr15);
        Drink dr16 = new Drink("", "", "dr_16_name");
        drinkList.Add(dr16);
        Drink dr17 = new Drink("", "", "dr_17_name");
        drinkList.Add(dr17);
        Drink dr18 = new Drink("", "", "dr_18_name");
        drinkList.Add(dr18);
        Drink dr19 = new Drink("", "", "dr_19_name");
        drinkList.Add(dr19);
        Drink dr20 = new Drink("", "", "dr_20_name");
        drinkList.Add(dr20);
        Drink dr21 = new Drink("", "", "dr_21_name");
        drinkList.Add(dr21);
        Drink dr22 = new Drink("", "", "dr_22_name");
        drinkList.Add(dr22);
        Drink dr23 = new Drink("", "", "dr_23_name");
        drinkList.Add(dr23);
        Drink dr24 = new Drink("", "", "dr_24_name");
        drinkList.Add(dr24);
        Drink dr25 = new Drink("", "", "dr_25_name");
        drinkList.Add(dr25);
        Drink dr26 = new Drink("", "", "dr_26_name");
        drinkList.Add(dr26);
        Drink dr27 = new Drink("", "", "dr_27_name");
        drinkList.Add(dr27);
        Drink dr28 = new Drink("", "", "dr_28_name");
        drinkList.Add(dr28);
        //i hate this
    }
}
