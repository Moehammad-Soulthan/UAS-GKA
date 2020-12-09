using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    Animator anim;

    private void Awake() {
        anim = this.GetComponent<Animator>();
    }

    public void setActive() {
        anim.SetTrigger("Active");
    }
}
