using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private PlayerModel model;
    private PlayerInput playerInput;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject spriteSpawnPrefab;

    void Awake()
    {
        playerInput    = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(model == null)
        {
            return;
        }

        //Debug.Log("i have selected " + model.HasSelected);
    }

    public void Init(PlayerModel model)
    {
        this.model = model;
        gameObject.transform.position = model.StartingPosition;

        model.HasSelected = false;

        spriteRenderer.sprite = model.Sprite; 
        
        if(model.IsLeftPlayer)
        {
            return;
        }

        playerInput.SwitchCurrentActionMap("PR");
        //Debug.Log(playerInput.currentActionMap);
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        PlayerController love = other.gameObject.GetComponent<PlayerController>();

        if(love == null)
        {
            return;
        }

        if(model.IsLeftPlayer)
        {
            Vector3 vc = new Vector3(-3,0,0);
            Instantiate(spriteSpawnPrefab,vc,Quaternion.identity);
        } else {
            Vector3 vc = new Vector3(3,0,0);
            Instantiate(spriteSpawnPrefab, vc,Quaternion.identity);
        }
    }

    public bool HasSelected()
    {
        return model.HasSelected;
    }

    public void Select()
    {
        model.HasSelected = true;
    }

}
