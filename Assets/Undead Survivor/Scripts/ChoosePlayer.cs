using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnChoosePlayer()
    {
        Debug.Log("Back button clicked");
        SceneManager.LoadScene("Home");
    }
}
