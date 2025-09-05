using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BtnShop()
    {
        Debug.Log("Home button clicked");
        SceneManager.LoadScene("Shop");
    }
    public void BtnPlay()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene("MainMenu");
    }
}
