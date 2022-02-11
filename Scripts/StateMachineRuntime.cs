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
    private string state;
    private string previousState = "";
    private int stateIndex;
    private Timer myTimer;
    private List<string> states = new List<string>();


    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        myTimer = GetNode<Timer>("Timer");

        //add all of the various states to the list
        GD.Print("Created new StateMachineRuntime");
        states.Add("Arrive");
        states.Add("Order");
        states.Add("Leave");

        //set the state and start the logic
        state = states[0];
        stateIndex = 0;
        //stateLogic();

        //DEBUGGING
        //ArriveLogic();
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
        stateLogic();
    }

    //logic for the first 'Arrive' state
    private void ArriveLogic() {
        //create a new character (maybe randomized to decide the image used)
        Random rand = new Random();
        int charType = rand.Next(0, 2);
        string chType;
        float fX, fY;

        //set the character type string and the correct x and y positions based on the random value generated
        switch (charType) {
            case 0: //case for apollo
                chType = "apollo.png";
                fX = 339;
                fY = 327;
                break;
            case 1: //case for serpent
                chType = "serpent.png";
                fX = 387;
                fY = 250;
                break;
            case 2: //case for unicorn
                chType = "unicorn.png";
                fX = 333;
                fY = 267;
                break;
            default: //default case
                GD.Print("ArriveLogic Random Number not valid result! Defaulting to Apollo.");
                chType = "apollo.png";
                fX = 339;
                fY = 327;
                break;
        }

        Sprite charSprite = GetParent().GetNode<Sprite>("CharacterSprite");
        charSprite.Texture = ResourceLoader.Load("res://Images/Characters/" + chType) as Texture;

        //have the new character 'walk' on screen
        //MoveSprite(charSprite, fX, fY);
    }

    //logic for the second 'Order' state
    private void OrderLogic() {
        //run the Order() method in the OrderSys 
    }

    //logic for the final 'Leave' state
    private void LeaveLogic() {
        //move the character off screen and then delete them
        //add points to point total (only if we do a points thingy)
        //change to the first state
    }

    //moves the sprite incrementally. 
    async private void MoveSprite(Sprite ch, float finalX, float finalY) {
        //set the sprites starting position to the correct y value off screen
        GD.Print("Started Moving Sprite");
        ch.Position = new Vector2(ch.Position.x, finalY);
        Vector2 nPos = new Vector2(0, 0);

        //incrementally move the sprite by updating the x value
        for (float i = ch.Position.x; i < finalX; i += 5) {
            nPos.x = i;
            ch.Position = nPos;

            //start the time and wait for it to finish
            myTimer.Start();
            await ToSignal(myTimer, "timeout");
        }

        //move onto the next state
        //NextState();
        GD.Print("Finished Moving Sprite");
    }

    //function that runs when the time ends.
    private void _on_Timer_timeout() {
        GD.Print("Timer Finished");
    }
}
