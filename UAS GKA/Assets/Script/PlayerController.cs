using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float LANE_DISTANCE = 2.5f;

    // Movement
    private CharacterController controller;
    private float jumpForce = 11f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    public float speed = 15.0f;
    private int desiredLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private bool isDead = false;
    Animator anim;

    private void Awake() {
        isDead = false;
        anim = this.GetComponent<Animator>();
    }


    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        
        if (Input.GetKey(KeyCode.Space)) {
            if (this.GetComponent<Animator>().GetBool("isGrounded") == true)
            {
                anim.SetBool("isGrounded", false);
            }
            else
            {
                anim.SetBool("isGrounded", true);
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            anim.SetBool("isTurnLeft", true);
        } else {
            anim.SetBool("isTurnLeft", false);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            anim.SetBool("isTurnRight", true);
        } else {
            anim.SetBool("isTurnRight", false);
        }
    }

    private void Update() {
        if (isDead)
            return;

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

        // Calculate Y
        if(IsGrounded()) { // If Grounded
            verticalVelocity = -0.1f;

            if(Input.GetKey(KeyCode.Space)) {
                // Jump
                verticalVelocity = jumpForce;   
            } 
        } else {
            verticalVelocity -= (gravity * Time.deltaTime);

            // Fast Falling Mechanic
            if(Input.GetKeyDown(KeyCode.Space)) {
                verticalVelocity = -jumpForce;
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void MoveLane(bool goingRight) {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    public void setSpeed(float modifier)
    {
        speed = 15.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log(hit.gameObject.name);
        if (hit.gameObject.CompareTag("Enemy"))
            Death();

        if (hit.gameObject.CompareTag("Potion")) {
            Destroy(hit.gameObject);
            speed -= 0.5f;
        }

        if (hit.gameObject.CompareTag("Increment")) {
            Destroy(hit.gameObject);
            speed += 1f;
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

    private bool IsGrounded() {
        Ray groundRay = new Ray(
            new Vector3(
                controller.bounds.center.x,
                (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
                controller.bounds.center.z), 
            Vector3.down);
        // Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f); 

        return Physics.Raycast(groundRay, 0.2f + 0.1f);
    }
}
