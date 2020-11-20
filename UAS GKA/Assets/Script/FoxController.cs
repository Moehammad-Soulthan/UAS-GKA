using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float speed = 10.0f;
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();
    }

    private void FixedUpdate() {
        float horizontalAxis = Input.GetAxis("Horizontal") * speed;
        horizontalAxis *= Time.fixedDeltaTime;
        transform.Translate(horizontalAxis, 0, 0);

        if (Input.GetMouseButton(0)) {
            anim.SetBool("isRunning", true);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            if (this.GetComponent<Animator>().GetBool("isGrounded") == true)
            {
                anim.SetBool("isGrounded", false);
            }
            else
            {
                anim.SetBool("isGrounded", true);
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetBool("isTurnLeft", true);
        } else {
            anim.SetBool("isTurnLeft", false);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("isTurnRight", true);
        } else {
            anim.SetBool("isTurnRight", false);
        }
    }
}
