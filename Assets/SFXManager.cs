using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip gameOverHit;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip doubleJumpPowerUp;
    [SerializeField] AudioClip shieldPowerUp;
    [SerializeField] AudioClip shieldBreak;
    // Start is called before the first frame update
    public void PlaySFX(string clipToPlay)
    {

        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = coin;
                break;
            case "Jump":
                audioSource.clip = jump;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJump;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHit;
                break;
            case "Land":
                audioSource.clip = land;
                break;
            case "DoubleJumpPowerUp":
                audioSource.clip = doubleJumpPowerUp;
                break;
            case "ShieldPowerUp":
                audioSource.clip = shieldPowerUp;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreak;
                break;
        }

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
