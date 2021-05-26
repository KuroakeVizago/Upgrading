using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinBox : MonoBehaviour
{
    [Header("Config : ")]
    [SerializeField] GameObject victoryBanner;
    [SerializeField] Text collectedCoinsText;
    [SerializeField] BallMovement ballPlayer;

    private void Start()
    {
        if (victoryBanner)
            victoryBanner.SetActive(false);

        if (!ballPlayer)
            ballPlayer = GameObject.FindObjectOfType<BallMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (collectedCoinsText)
                collectedCoinsText.text = ballPlayer.coinCollected + " Coins Collected";
            
            victoryBanner.SetActive(true);



        }
    }


}
