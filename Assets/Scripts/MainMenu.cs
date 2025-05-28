using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image Logo;
    void Start()
    {
        Logo.gameObject.SetActive(true);  
    }
    public void PlayGame()
    {
        Logo.gameObject.SetActive(false);
        SceneManager.LoadScene("Levels");
    }
    public void QuitGame()
    { 
        Application.Quit(); 
    }
}
