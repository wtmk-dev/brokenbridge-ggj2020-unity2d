using System;
using System.Collections;
using System.Collections.Generic;

public class StateManager
{
    public Action<State> OnStateChange;
    private List<State> states;
    private State previousState;
    public State CurrentState{get; set;}

    public StateManager(List<State> states)
    {
        this.states   = states;
        previousState = states[0];
        CurrentState  = states[0];
    }

    public State GetPreviousState()
    {
        return previousState;
    }

    public void StateChange(State state)
    {
        previousState = CurrentState;
        CurrentState = state;

        if(OnStateChange != null)
        {
            OnStateChange(CurrentState);
        }
    }
}
