using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distancedTraveled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] Text coinsCollected;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        //distancedTraveled.text = player.distancedTraveled.ToString();
        float distancedRounded = Mathf.Ceil(player.distancedTraveled);
        distancedTraveled.text = "" + distancedRounded;
        coinsCollected.text = "" + player.collectedCoins;
    }

    public void GameRestart()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene("EndlessRunner");
    }
}
