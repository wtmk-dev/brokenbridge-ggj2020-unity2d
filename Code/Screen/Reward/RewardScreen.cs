using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RewardScreen : MonoBehaviour, IScreen
{
    private StateManager stateManager;

    [SerializeField]
    private State state,nextState,start;
    [SerializeField]
    private TextMeshProUGUI rewardText;
    [SerializeField]
    private Button resetButton;

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

    // public void DisplayScore(bool failed, ScoreCard scoreCard)
    // {
    //     if(failed)
    //     {
    //         rewardText.text = "oh no... typical?";
    //     } else {
    //         rewardText.text = "Time remaining: " + scoreCard.time + "\n" +
    //                           "Total strikes: " + scoreCard.strikes;
    //     }

    // }
    public State GetState()
    {
        return state;
    }

    private void ResetButton()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
