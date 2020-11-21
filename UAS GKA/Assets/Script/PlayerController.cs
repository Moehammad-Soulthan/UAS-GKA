using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float LANE_DISTANCE = 2.5f;

    // Movement
    private CharacterController controller;
    // private float jumpForce = 4.0f;
    // private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 15.0f;
    private int desiredLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();
    }


    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (this.GetComponent<Animator>().GetBool("isGrounded") == true)
            {
                anim.SetBool("isGrounded", false);
            }
            else
            {
                anim.SetBool("isGrounded", true);
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            anim.SetBool("isTurnLeft", true);
        } else {
            anim.SetBool("isTurnLeft", false);
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            anim.SetBool("isTurnRight", true);
        } else {
            anim.SetBool("isTurnRight", false);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            MoveLane(false);
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            MoveLane(true);

        Vector3 targetPosition = transform.position.z * Vector3.forward;

        if(desiredLane == 0) {
            targetPosition += Vector3.left * LANE_DISTANCE;
        } else if(desiredLane == 2) {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void MoveLane(bool goingRight) {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

}
