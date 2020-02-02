using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScreen : MonoBehaviour, IScreen
{
    private StateManager stateManager;
    private Timer roundTimer;
    private bool isActive;
    public float RoundTime{get;set;}
    public bool RoundOver = false;

    [SerializeField]
    private State state, nextState;
    [SerializeField]
    private TextMeshProUGUI roundTimerText;
    [SerializeField]
    private List<Image> strikes;
    [SerializeField]
    private Image heart;

    void Update()
    {
        if(stateManager == null)
        {
            return;
        }

        if(isActive)
        {
            UpdateRoundTimer();

            int timeRemaining = (int) RoundTime - (int) roundTimer.GetElapedTime();
            roundTimerText.text = timeRemaining.ToString();
        }

        if(stateManager.CurrentState != state)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init(StateManager stateManager)
    {
        this.stateManager = stateManager;

        roundTimer = new Timer();
        roundTimerText.text = RoundTime.ToString();

        heart.fillAmount = 0.3f;

        RoundOver = false;

        HideStrikes();
        SetVisable(false);
    }

    public State GetState()
    {
        return state;
    }

    public void SetVisable(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;
    }

    public void ShowStrike(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            strikes[i].gameObject.SetActive(true);
        }
    }

    public void HideStrikes()
    {
        for(int i = 0; i < strikes.Count; i++)
        {
            strikes[i].gameObject.SetActive(false);
        }
    }

    public void StartTimer()
    {
        if(stateManager == null || stateManager.CurrentState != state)
        {
            return;
        }

        isActive = true;
    }

    public void SetPanicTime(float panicTime)
    {
        if(panicTime > RoundTime)
        {
            RoundTime = panicTime;
        }
        
        roundTimerText.text = RoundTime.ToString();
    }

    public void FillHeart(float f)
    {
        heart.fillAmount += f;
    }

    public float HeartFillAmout()
    {
        return heart.fillAmount;
    }

    public void AddTime(float f)
    {
        RoundTime += f;
    }

    private void UpdateRoundTimer()
    {
        if(!roundTimer.IsLocked())
        {
            roundTimer.SetLock(true);
            roundTimer.SetTimer(RoundTime);
        }

        if(roundTimer.IsLocked())
        {
            roundTimer.RecordTime(Time.deltaTime);
        }

        if(roundTimer.IsDone() && isActive)
        {
            isActive = false;
            RoundOver = true;
            roundTimer.SetLock(false);
        }
    }

    
}
