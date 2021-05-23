using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();

    string animationState = "AnimationState";
    Rigidbody2D rb2D;
    Animator animator;

    enum charStates
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4,
        Idle = 0
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateState();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    public void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)charStates.East);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)charStates.West);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)charStates.North);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)charStates.South);
        }
        else
        {
            animator.SetInteger(animationState, (int)charStates.Idle);
        }
    }

}