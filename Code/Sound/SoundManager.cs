using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private StateManager stateManager;

    [SerializeField]
    private List<AudioClip> audioClips;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Init(StateManager stateManager)
    {
        this.stateManager = stateManager;

        stateManager.OnStateChange += HandelStateChange;
    }

    private void HandelStateChange(State state)
    {
        Debug.Log("SoundManager " + state.id);
        switch(state.id)
        {
            case 0:
            
            break;

            case 1:
            audioSource.clip = audioClips[0];
            audioSource.Play();
            break;
        }
    }


}
