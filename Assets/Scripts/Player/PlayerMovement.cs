using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float playerSpeed = 1f;

    private MainInput controls;
    private Vector2 moveDirection = Vector2.zero;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float verticalVelocity = 0f;

    // Jumping
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private bool isJumping = false;
    #endregion

    private void Awake()
    {
        this.controls = new MainInput();
        this.characterController = this.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        this.controls.Enable();

    }
    private void OnDisable()
    {
        this.controls.Disable();
    }

    private void Update()
    {
        this.moveDirection = this.controls.PlayerMovement.Movement.ReadValue<Vector2>();
        if (this.controls.PlayerMovement.Jump.triggered)
        {
            this.isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(this.moveDirection.x, 0f, this.moveDirection.y);
        move = this.transform.TransformDirection(move);

        if (this.characterController.isGrounded)
        {
            if (this.verticalVelocity < 0)
            {
                this.verticalVelocity = -2f; // Small value to stay grounded
            }

            if (this.isJumping)
            {
                this.verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                this.isJumping = false; // Consume the jump input
            }
        }
        else
        {
            this.verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = this.verticalVelocity;
        this.characterController.Move(move * this.playerSpeed * Time.deltaTime);
    }


}
