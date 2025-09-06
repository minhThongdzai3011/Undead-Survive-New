using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSaver : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnGoToLogin()
    {
        LoadingGame.instance.loadingObj.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Login");
    }
}
