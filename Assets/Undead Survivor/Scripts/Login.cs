using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject login;
    public GameObject signUp;
    public TMP_InputField usernameInputLogin;
    public TMP_InputField passwordInputLogin;
    public TextMeshProUGUI loginSaveText;
    public TextMeshProUGUI textError;
    public string usernameSave;
    public string passwordSave;
    private int count = 0;
    public Image imageError;
    public Image imageNoError;

    public Image imageSay;
    public Image imageNoSay;
    public TextMeshProUGUI textSay;

    public TMP_InputField usernameInputSignUp;
    public TMP_InputField passwordInputSignUp;
    public TMP_InputField passwordAgainInputSignUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        int count = PlayerPrefs.GetInt("accountCount", 0);
        loginSaveText.text = "Danh sach tai khoan:\n";
        for (int i = 0; i < count; i++)
        {
            string user = PlayerPrefs.GetString("username_" + i);
            string pass = PlayerPrefs.GetString("password_" + i);
            loginSaveText.text += $" Account {i + 1}: Username = {user}, Password = {pass}\n";
        }
    }

    public void BtnGoToHome()
    {
        int count = PlayerPrefs.GetInt("accountCount", 0);
        Debug.Log("Username: " + usernameInputLogin.text + "Password: " + passwordInputLogin.text);
        if (count == 0)
        {
            Debug.Log("No accounts registered. Please sign up first.");
            imageError.gameObject.SetActive(true);
            imageSay.gameObject.SetActive(true);
            imageNoError.gameObject.SetActive(false);
            imageNoSay.gameObject.SetActive(false);
            textError.text = "No accounts registered. Please sign up first.";
            string[] items = { "Oh no !!!", ":(((", "I belive You" };
            string randomItem = items[Random.Range(0, items.Length)];
            textSay.text = randomItem;
            return;
        }
        for (int i = 0; i < count; i++)
        {
            string savedUsername = PlayerPrefs.GetString("username_" + i);
            string savedPassword = PlayerPrefs.GetString("password_" + i);
            if (usernameInputLogin.text == savedUsername && passwordInputLogin.text == savedPassword)
            {
                string tempUsername = usernameInputLogin.text;
                PlayerPrefs.SetString("username_", tempUsername);
                Debug.Log("Login successful! Welcome, " + savedUsername);
                LoadingGame.instance.loadingObj.SetActive(true);
                SceneManager.LoadScene("Home");
                return;
            }
            else
            {
                Debug.Log($"Login failed: Incorrect username or password.  { count} " );
                imageError.gameObject.SetActive(true);
                imageSay.gameObject.SetActive(true);
                imageNoError.gameObject.SetActive(false);
                imageNoSay.gameObject.SetActive(false);
                textError.text = "Login failed: Incorrect username or password.";
                string[] items = { "Oh no !!!", ":(((", "I belive You" };
                string randomItem = items[Random.Range(0, items.Length)];
                textSay.text = randomItem;
            }
        }
        
    }

    public void BtnRegister()
    {
        if (passwordInputSignUp.text == passwordAgainInputSignUp.text)
        {
            int count = PlayerPrefs.GetInt("accountCount", 0);
            PlayerPrefs.SetString("username_" + count, usernameInputSignUp.text);
            PlayerPrefs.SetString("password_" + count, passwordInputSignUp.text);
            count++;
            PlayerPrefs.SetInt("accountCount", count);
            Debug.Log("Registration successful! You can now log in with your new account.");
            login.gameObject.SetActive(true);
            signUp.gameObject.SetActive(false);
        }
        else
        {
            count ++;
            imageError.gameObject.SetActive(true);
            imageSay.gameObject.SetActive(true);
            imageNoError.gameObject.SetActive(false);
            imageNoSay.gameObject.SetActive(false);
            string[] items = { "Oh no !!!", ":(((", "I belive You" };
            string randomItem = items[Random.Range(0, items.Length)];
            textSay.text = randomItem;
            textError.text = "Registration failed: Passwords do not match.";
        }
    }

    public void BtnGoToRegister()
    {
        login.gameObject.SetActive(false);
        signUp.gameObject.SetActive(true);
    }

    public void BtnGoToLogin()
    {
        login.gameObject.SetActive(true);
        signUp.gameObject.SetActive(false);
    }
    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        LoadingGame.instance.loadingObj.SetActive(false);
    }

}
