using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text timePlay;
    private float timerFloat = 0f;
    private TimeSpan timerTime;
    public Player player;

    public TextMeshProUGUI TextEnemy;

    public TextMeshProUGUI killTextWin;
    public TextMeshProUGUI timeTextWin;
    public TextMeshProUGUI coinTextWin;
    public TextMeshProUGUI killTextLose;
    public TextMeshProUGUI timeTextLose;
    public TextMeshProUGUI coinTextLose;

    public TextMeshProUGUI coinTextStrPlay;
    public GameObject victory;
    private bool isTimeStopped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimeStopped)
        {
            timerFloat += Time.deltaTime;
            timerTime = TimeSpan.FromSeconds(timerFloat);
            timePlay.text = timerTime.ToString(@"mm\:ss");
        }
        coinTextStrPlay.text = player.countCoin.ToString();
        if (player.isLose)
        {
            isTimeStopped = true; 
            timeTextLose.text = "Time: " + timePlay.text;
            killTextLose.text = "Kill: " + player.countEnemy.ToString();
            coinTextLose.text = "Coin: " + player.countCoin.ToString();
        }
        if(TextEnemy != null)
        {
            TextEnemy.text = "Enemy: " + (3 - player.countEnemy).ToString();
        }
        if (TextEnemy != null && player.countEnemy >= 3)
        {
            victory.SetActive(true);
            isTimeStopped = true;
            timeTextWin.text = "Time: " + timePlay.text;
            killTextWin.text = "Kill: " + player.countEnemy.ToString();
            coinTextWin.text = "Coin: " + player.countCoin.ToString();
        }
    }

    public void BtnHome()
    {
        Debug.Log("Home button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadHome());
    }
    public void BtnNext()
    {
        Debug.Log("Home button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadPlayMap1());
    }
    public void BtnPlayAgain()
    {
        Debug.Log("Play Again button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadPlayAgain());
    }



    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        LoadingGame.instance.loadingObj.SetActive(false);
    }

    IEnumerator loadHome()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Home");
    }

    IEnumerator loadPlayMap1()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map1");
    }

    IEnumerator loadPlayAgain()
    {
        yield return new WaitForSeconds(2f);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
