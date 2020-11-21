using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToGameScene : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }
    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Game");
        }
    }
    */
}
