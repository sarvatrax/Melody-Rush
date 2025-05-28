using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfCoins;
    public TMP_Text coinsText;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinsText.text = "Coins\n" + numberOfCoins;

        if(SwipeManager.tap && !isGameStarted) 
        {
            isGameStarted = true;
            Destroy(startingText);
            Object.FindFirstObjectByType<AudioManager>().PlayRandomSong();
        }
    }
}
