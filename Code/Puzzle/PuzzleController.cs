using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    private PuzzlePiece puzzlePiece;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private float speed = 0;
    private float startTime = 0;
    private float journeyLength = 0;
    private bool isActive = false;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource    = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(puzzlePiece == null)
        {
            return;
        }

        if(transform.position.y <= puzzlePiece.endPos.y)
        {
            gameObject.transform.position = puzzlePiece.startPos;
        }
    }

    void Update()
    {
         if(puzzlePiece == null)
        {
            return;
        }

        if(isActive)
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!isActive)
        {
            return;
        }
        
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if(player == null)
        {
            return;
        }

        if(!player.HasSelected())
        {
            Debug.Log("i was selected");
            isActive = false;
            player.Select();
            audioSource.Play();
            puzzlePiece.SelectPiece();  
        }
    }

    public void Init(PuzzlePiece puzzlePiece)
    {
        this.puzzlePiece = puzzlePiece;
        gameObject.transform.position = puzzlePiece.startPos;
        spriteRenderer.sprite = puzzlePiece.sprite;
        speed = puzzlePiece.speed;
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;   
    }

    public void SetVisable(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public bool IsLeftSide()
    {
        return puzzlePiece.isLeftSide;
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, puzzlePiece.endPos, step);
    }

}
