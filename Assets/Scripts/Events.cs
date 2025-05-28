using UnityEngine;
using UnityEngine.SceneManagement;
public class Events : MonoBehaviour
{
   public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Levels");
    }    

    public void QuitGame()
    {
        Application.Quit(); 
    }
}

