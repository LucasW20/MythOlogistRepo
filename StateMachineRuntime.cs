using Godot;
using System;
using System.Collections.Generic;

/***
 * Handles the different states that the game goes through
 * @author Lucas_C_Wright
 * @start 2-7-2022
 * @version 2-9-2022
 */
public abstract class StateMachineRuntime {
    private string state;
    private string previousState = "";
    private int stateIndex;
    List<string> states = new List<string>();


    // Called when the node enters the scene tree for the first time.
    public StateMachineRuntime () {
        //add all of the various states to the list
        GD.Print("Created new StateMachineRuntime");
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
        stateLogic();
    }

    private void ArriveLogic() {
        //create a new character (maybe randomized to decide the image used)
        GetNode<Sprite>
        
        //have the new character 'walk' on screen
        //change to the next state
    }

    private void OrderLogic() {
        //run the Order() method in the OrderSys 
    }

    private void LeaveLogic() {
        //move the character off screen and then delete them
        //add points to point total (only if we do a points thingy)
        //change to the first state
    }

    

    /*
    public abstract void stateLogic();

    public abstract void enterState(string newState, string oldState);

    public abstract void exitState(string oldState, string newState);

    public abstract void transition();

    public void ChangeState(string nState) {
        previousState = state;
        state = nState;

        if (previousState != null) {
            exitState(previousState, state);
        }
        if (nState != null) {
            enterState(nState, previousState);
        }

    }
    */
}
