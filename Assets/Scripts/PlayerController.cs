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

    // Public
    public Animator animator;

    public float Gravity = 9.8f;

    public float JumpForce;

    public float Speed;

    public float ShiftSpeed;

    public float StandartSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movement
        _moveVector = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = ShiftSpeed;
            animator.SetBool("isFastRun", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = StandartSpeed;
            animator.SetBool("isFastRun", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded && _isJump == false)
        {
            StartCoroutine(Jump());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        //Fall and Jump
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
    public IEnumerator Jump()
    {
        _isJump = true;
        animator.SetBool("isGrounded", false);
        yield return new WaitForSeconds(0.45f);
        _fallVelocity = -JumpForce;
        yield return new WaitForSeconds(0.25f);
        _isJump = false;
    }
}
