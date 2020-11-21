using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFoxController : MonoBehaviour
{
    // public float speedX = 10.0f;
    // public float speedZ = 10.0f;
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();
    }

    private void FixedUpdate() {
        // float horizontalAxis = Input.GetAxis("Horizontal") * speedX;
        // horizontalAxis *= Time.fixedDeltaTime;
        // float vertical = speedZ * Time.fixedDeltaTime;
        // transform.Translate(horizontalAxis, 0, 0);
        // transform.Translate(0, 0, vertical);
        
        if (Input.GetMouseButton(0)) {
            // anim.SetBool("isRunning", true);
        } 
        else if (Input.GetKeyDown(KeyCode.Space)) {
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
    
}
