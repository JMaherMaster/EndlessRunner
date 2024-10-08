using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distancedTraveled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        //distancedTraveled.text = player.distancedTraveled.ToString();
        float distancedRounded = Mathf.Ceil(player.distancedTraveled);
        distancedTraveled.text = "" + distancedRounded;
    }

    public void GameRestart()
    {
        Debug.Log("Restart the game");
    }
}
