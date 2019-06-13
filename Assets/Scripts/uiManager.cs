using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    bool gameOver;
    int score;
    public Button[] buttons;

    UnityEngine.SceneManagement.Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;
        InvokeRepeating("scoreUpdate", 3.0f, 1.0f);
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "level1") {
            scoreText.text = "Score : " + score;
        }
    }

    private void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    public void gameOverFN()
    {
        gameOver = true;

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void Play()
    {
        Application.LoadLevel("level1");
    }

    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Menu()
    {
        Application.LoadLevel("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
