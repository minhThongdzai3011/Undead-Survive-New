using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Home : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BtnShop()
    {
        Debug.Log("Home button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadShop());
    }
    public void BtnPlay()
    {
        Debug.Log("Play button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadPlay());
    }

    public void BtnChangePlayer()
    {
        Debug.Log("Exit button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadChangePlayer());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        LoadingGame.instance.loadingObj.SetActive(false);
    }

    IEnumerator loadShop()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Shop");
    }

    IEnumerator loadPlay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator loadChangePlayer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Player");
    }
}
