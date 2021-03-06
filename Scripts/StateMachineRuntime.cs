using Godot;
using System;
using System.Collections.Generic;

/***
 * Handles the different states that the game goes through
 * @author Lucas_C_Wright
 * @start 2-7-2022
 * @version 2-11-2022
 */
public abstract class StateMachineRuntime : Node {
	//class variables
	private string state;
	private string previousState;
	private int stateIndex;
	private List<string> states = new List<string>();

	//nodes in scene
	private Sprite charSprite;
	private Timer myTimer;
	private OrderSys orderSystem;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		//assign variables
		myTimer = GetNode<Timer>("Timer");
		charSprite = GetNode<Sprite>("CharacterSprite");
		orderSystem = GetParent().GetNode<OrderSys>("Order System");

		//add all of the various states to the list
		//GD.Print("Created new StateMachineRuntime");
		states.Add("Arrive");
		states.Add("Order");
		states.Add("Leave");

		//set the state and start the logic
		state = states[0];
		stateIndex = 0;
		stateLogic();
	}


	//determines what happens when for each stage
	public void stateLogic() {
		//depending on the current state this decides which logic is going to play out.
		switch (state) {
			case "Arrive":
				ArriveLogic();
				break;
			case "Order":
				OrderLogic();
				break;
			case "Leave":
				LeaveLogic();
				break;
			default:
				GD.Print("StateMachineRuntime state variable not valid state!");
				break;
		}
	}

	//Moves the state machine to the next state. This also starts the logic for that state
	public void NextState() {
		//if we're at the end of the array then make the stateIndex 0 to restart the StateMachine
		if (stateIndex != states.Count - 1) {
			stateIndex++;
		} else {
			stateIndex = 0;
			GD.Print("Reset StateMachineRuntime to start over!");
		}

		//update the previousState and update the state with the new index value
		previousState = state;
		state = states[stateIndex];
		GD.Print("New State: " + state);
		stateLogic();
	}

	//logic for the first 'Arrive' state
	private void ArriveLogic() {
		//create a new character (maybe randomized to decide the image used)
		Random rand = new Random();
		int charType = rand.Next(0, 2);

		//these are the variables that change based on which character is chosen by the randomizer
		string chType;
		float fX, fY;

		//set the character type string and the correct x and y positions based on the random value generated
		switch (charType) {
			case 0: //case for apollo
				chType = "apollo.png";
				fX = 348;
				fY = 329;
				break;
			case 1: //case for serpent
				chType = "serpent.png";
				fX = 384;
				fY = 252;
				break;
			case 2: //case for unicorn
				chType = "unicorn.png";
				fX = 361;
				fY = 268;
				break;
			default: //default case
				GD.Print("ArriveLogic Random Number not valid result! Defaulting to Apollo.");
				chType = "apollo.png";
				fX = 348;
				fY = 329;
				break;
		}

		//load the character sprite with the character texture
		charSprite.Texture = ResourceLoader.Load("res://Images/Characters/" + chType) as Texture;

		//have the new character 'walk' on screen
		MoveSprite(fX, fY, true);
	}

	//logic for the second 'Order' state
	private void OrderLogic() {
		GetParent().GetParent().GetNode<Sprite>("glass").Texture = ResourceLoader.Load("res://Images/glassV01.png") as Texture;
		orderSystem.Order();
	}

	//logic for the final 'Leave' state
	private void LeaveLogic() {
		//move the character off screen and then delete them
		MoveSprite(-289, charSprite.Position.y, false);
	}

	//moves the sprite incrementally. 
	async private void MoveSprite(float finalX, float finalY, bool enter) {
		//set the sprites starting position to the correct y value off screen
		//GD.Print("Started Moving Sprite.");
		charSprite.Position = new Vector2(charSprite.Position.x, finalY);
		Vector2 nPos = new Vector2(0, finalY);

		if (enter) {
			//incrementally move the sprite by updating the x value
			for (float i = charSprite.Position.x; i < finalX; i += 5) {
				nPos.x = i;
				charSprite.Position = nPos;
				//GD.Print("X: " + ch.Position.x + " Y: " + ch.Position.y);

				//start the time and wait for it to finish
				myTimer.Start();
				await ToSignal(myTimer, "timeout");
			}
		} else {
			//incrementally move the sprite by updating the x value
			for (float i = charSprite.Position.x; i > finalX; i -= 5) {
				nPos.x = i;
				charSprite.Position = nPos;
				//GD.Print("X: " + ch.Position.x + " Y: " + ch.Position.y);

				//start the time and wait for it to finish
				myTimer.Start();
				await ToSignal(myTimer, "timeout");
			}
		}

		//move onto the next state
		//GD.Print("Finished Moving Sprite");
		NextState();
	}

	//function that runs when the time ends.
	private void _on_Timer_timeout() {
		//GD.Print("Timer Finished");
	}
}
