using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
  [SerializeField]
  float speed = 3;

  [SerializeField]
  float jumpForce = 300;

  [SerializeField]
  float gravityMultiplier = 4;

  Vector2 inputVector;
  float yVelocity = 0;
  bool isJumping = false;

  void Update()
  {
    Vector3 movement = transform.forward * inputVector.y + 
                        transform.right * inputVector.x;
    movement *= speed;

    if (GetComponent<CharacterController>().isGrounded == true)
    {
      yVelocity = -1;
      if (isJumping == true)
      {
        yVelocity = jumpForce;
      }
    }

    yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
    movement.y = yVelocity;

    isJumping = false;
    GetComponent<CharacterController>().Move(movement * Time.deltaTime);
  }

  void OnMove(InputValue value) => inputVector = value.Get<Vector2>();
  void OnJump(InputValue value) => isJumping = true;
}	