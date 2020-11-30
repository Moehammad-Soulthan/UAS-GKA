using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 7;
    private int toNextDifficulty = 30;
    private bool isDead = false;

    public Text scoreText;
    public DeathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (score >= toNextDifficulty)
            LevelUp();

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        toNextDifficulty *= 2;
        difficultyLevel++;

        GetComponent<PlayerController>().setSpeed(difficultyLevel);
        GameObject.Find("Camera").GetComponent<CameraPosition>().setPosition();
    }

    public void OnDeath()
    {
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);
        deathMenu.ToggleEndMenu(score);
    }
}
