using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Shop : MonoBehaviour
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

    public void BtnHome()
    {
        Debug.Log("Exit button clicked");
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadHome());
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
}
