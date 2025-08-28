using UnityEngine;
using UnityEngine.UI;

public class CodeHp : MonoBehaviour
{
    public Image _thanhMau;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float nowHealth, float maxHealth)
    {
        _thanhMau.fillAmount = nowHealth/maxHealth;
    }
}
