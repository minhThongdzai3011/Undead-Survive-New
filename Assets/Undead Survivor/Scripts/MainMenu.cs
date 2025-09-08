using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
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

    public void BtnPlay()
    {
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(loadChangePlayer());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        LoadingGame.instance.loadingObj.SetActive(false);
    }

    IEnumerator loadChangePlayer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map1");
    }
}
