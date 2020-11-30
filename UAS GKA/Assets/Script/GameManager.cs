using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas credit;
    public Button play;


    void Start()
    {
        credit.enabled = false;
        play.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void creditshow()
    {
        credit.enabled = !credit.enabled;
        play.enabled = !play.enabled;
    }
}
