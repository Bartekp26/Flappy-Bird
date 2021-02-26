using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    private Text highscoreText;
    private Text scoreText;

    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();
        transform.Find("retryButton").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene); };
        transform.Find("retryButton").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MainMenu); };
        transform.Find("mainMenuBtn").GetComponent<Button_UI>().AddButtonSounds();
    }

    private void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();

        if (Level.GetInstance().GetPipesPassedCount() >= Score.GetHighscore()) {
            // New Highscore
            highscoreText.text = "NEW HIGHSCORE";
        } else {
            highscoreText.text = "HIGHSCORE: " + Score.GetHighscore();
        }
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
