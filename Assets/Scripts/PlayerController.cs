using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private
    private CharacterController _characterController;
    
    private float _fallVelocity = 0;

    private Vector3 _moveVector;

    private bool _isJump;

    private bool _isFalse = true;

    // Public
    public Animator animator;

    public float Gravity = 9.8f;

    public float JumpForce;

    public float Speed;

    public float ShiftSpeed;

    public float StandartSpeed;

    public int MaxGranade = 3;

    public int CurrentGranade;

    public bool IsDeath = false;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_isFalse == true && IsDeath == false)
        {
            Movement();
            JumpMove();
        }
    }

    private void JumpMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded && _isJump == false)
        {
            _fallVelocity = -JumpForce;
        }
    }

    private void Movement()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            animator.SetInteger("Run Direction", 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            animator.SetInteger("Run Direction", 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            animator.SetInteger("Run Direction", 4);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            animator.SetInteger("Run Direction", 3);
        }

        if (_moveVector == Vector3.zero)
        {
            animator.SetInteger("Run Direction", 0);
        }
    }

    void FixedUpdate()
    {
        // Movement
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);
        FallAndJump();
    }

    private void FallAndJump()
    {
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    public void AddGranade()
    {
        if(CurrentGranade < MaxGranade)
        {
            CurrentGranade += 1;
        }
    }
}
