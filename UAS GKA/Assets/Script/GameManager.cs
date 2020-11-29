using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas credit;
    void Start()
    {
        credit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void creditshow()
    {
        credit.enabled = !credit.enabled;
    }
}
