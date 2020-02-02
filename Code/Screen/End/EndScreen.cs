using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour, IScreen
{
    private StateManager stateManager;

    public State state;

    public Button resetButton;
    
    void Awake()
    {
        resetButton.onClick.AddListener(ResetButton);
    }

    void Update()
    {
        if(stateManager.CurrentState != state)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public void SetVisable(bool isActive)
    {
        gameObject.SetActive(isActive);

    }

      private void ResetButton()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

       public State GetState()
    {
        return state;
    }

}
