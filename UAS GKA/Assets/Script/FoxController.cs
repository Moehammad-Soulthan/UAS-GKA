using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float speed = 5.0f;
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();

    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal") * speed;
        h *= Time.fixedDeltaTime;
        transform.Translate(h, 0, 0);
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isRunning", true);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.GetComponent<Animator>().GetBool("isGrounded") == true)
            {
                anim.SetBool("isGrounded", false);
            }
            else
            {
                anim.SetBool("isGrounded", true);
            }
        }

    }
}
