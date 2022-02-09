using Godot;
using System;
using System.Collections.Generic;

/***
 * Handles the different states that the game goes through
 * @author Lucas_C_Wright
 * @start 2-7-2022
 * @version 2-7-2022
 */
public abstract class StateMachineRuntime {
    string state = "";
    string previousState = "";
    List<string> states = new List<string>();


    // Called when the node enters the scene tree for the first time.
    public StateMachineRuntime () {
        states.Add("Arrive");
        states.Add("Order");
        states.Add("Input");
        states.Add("Leave");
    }



    public void stateLogic(string cState) {

    }

    private void ArriveLogic() {

    }

    private void OrderLogic() {

    }

    private void InputLogic() {

    }

    private void LeaveLogic() {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


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
