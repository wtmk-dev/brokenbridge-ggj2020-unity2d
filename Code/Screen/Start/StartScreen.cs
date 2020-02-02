using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour, IScreen
{
    [SerializeField]
    private State state,nextState;
    private StateManager stateManager;

    [SerializeField]
    private Button startButton;

    void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }


    public void Init(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public State GetState()
    {
        return state;
    }


    private void StartGame()
    {
        if(stateManager == null)
        {
            return;
        }

        stateManager.StateChange(nextState);
        
        gameObject.SetActive(false);
    }
}
