﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using InControl;

public class Player : MonoBehaviour
{
    private enum State
    {
        None,
        Idle,
        Walk,
        Jump
    }

    private State currentState_ = State.None;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private PlayerFoot foot;
    
    private const float DeadZone = 0.001f;
    private const float MoveSpeed = 2.0f;
    private const float JumpSpeed = 5.0f;

    private bool facingRight_ = true;
    private bool jumpButtonDown_ = false;
    //private bool interactButtonDown_ = false;
    

    private void Start()
    {
        ChangeState(State.Idle);
    }

    private void Update()
    {
        var inputDevice = InputManager.ActiveDevice;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpButtonDown_ = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonDown_ = true;
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            interactButtonDown_ = true;
        }*/
    }

    private void FixedUpdate()
    {
        float moveDir = Input.GetAxis("Horizontal");

        if (foot.FootContact > 0 && jumpButtonDown_)
        {
            Jump();
        }
        

        jumpButtonDown_ = false;

        var vel = body.velocity;
        body.velocity = new Vector2(MoveSpeed * moveDir, vel.y);

        if (moveDir > DeadZone && !facingRight_)
        {
            Flip();
        }

        if (moveDir < -DeadZone && facingRight_)
        {
            Flip();
        }

        switch (currentState_)
        {
            case State.Idle:
                if (Mathf.Abs(moveDir) > DeadZone)
                {
                    ChangeState(State.Walk);
                }

                if (foot.FootContact == 0)
                {
                    ChangeState(State.Jump);
                }

                break;
            case State.Walk:
                if (Mathf.Abs(moveDir) < DeadZone)
                {
                    ChangeState(State.Idle);
                }

                if (foot.FootContact == 0)
                {
                    ChangeState(State.Jump);
                }

                break;
            case State.Jump:
                if (foot.FootContact > 0)
                {
                    ChangeState(State.Idle);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
    
    private void Jump()
    {
        var vel = body.velocity;
        body.velocity = new Vector2(vel.x, JumpSpeed);
        FindObjectOfType<AudioManager>().Play("Jump");
    }
    
    void ChangeState(State state)
    {
        switch (state)
        {
            case State.Idle:
                anim.Play("Idle");
                break;
            case State.Walk:
                anim.Play("Walk");
                break;
            case State.Jump:
                anim.Play("Jump");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }

        currentState_ = state;
    }
    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        facingRight_ = !facingRight_;
    }
}