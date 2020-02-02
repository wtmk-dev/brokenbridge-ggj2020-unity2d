using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour 
{
    private Rigidbody2D rb2d;
    private Animator animator;
    private AudioSource audioSource;
    private float vertical = 0f;

    public float Vertical { set {
        vertical = value;
    }}

    private float horizontal = 0f;

    public float Horizontal { set {
        horizontal = value;
    }}

    private float speed = 2f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        Init();
    }
    
    void FixedUpdate() 
    {
        if( rb2d == null )
        {
            return;
        }

        Move();
    }

    private void Init()
    {
        rb2d.gravityScale = 0;
    }

    private void Move()
    {
       SetHorizontalAnimationStates();
       SetVerticalAnimationStates();

        Vector3 dir = new Vector3(horizontal, vertical, 0f);
        rb2d.velocity = dir * 4;

        if(horizontal != 0 || vertical != 0)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void SetHorizontalAnimationStates()
    {
        if(horizontal > 0)
        {
            animator.SetBool("Left", true);
        }

        if(horizontal < 0)
        {
            animator.SetBool("Right", true);
        }

        if(horizontal == 0)
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
    }

    private void SetVerticalAnimationStates()
    {
        if(vertical > 0)
        {
            animator.SetBool("Up", true);
        }

        if(vertical < 0)
        {
            animator.SetBool("Down", true);
        }

        if(vertical == 0)
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }

}
