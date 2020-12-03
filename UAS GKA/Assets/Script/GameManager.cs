using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas credit;
    public Canvas highscore;
    public Canvas howToPlay;
    public Button play;
    public GameObject creditPanel;
    public GameObject highscorePanel;
    public GameObject howToPlayPanel;


    void Start()
    {
        credit.enabled = false;
        highscore.enabled = false;
        howToPlay.enabled = false;
        play.enabled = true;
        creditPanel.gameObject.SetActive (false);
        highscorePanel.gameObject.SetActive (false);
        howToPlayPanel.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void creditshow()
    {
        credit.enabled = !credit.enabled;
        play.enabled = !play.enabled;

        if(credit.enabled) {
            creditPanel.gameObject.SetActive (true);
        } else {
            creditPanel.gameObject.SetActive (false);
        } 
    }
    
    public void highscoreshow()
    {
        highscore.enabled = !highscore.enabled;
        play.enabled = !play.enabled;

        if(highscore.enabled) {
            highscorePanel.gameObject.SetActive (true);
        } else {
            highscorePanel.gameObject.SetActive (false);
        } 
    }

    public void howToPlayshow()
    {
        howToPlay.enabled = !howToPlay.enabled;
        play.enabled = !play.enabled;

        if(howToPlay.enabled) {
            howToPlayPanel.gameObject.SetActive (true);
        } else {
            howToPlayPanel.gameObject.SetActive (false);
        } 
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!!");
    }
}
