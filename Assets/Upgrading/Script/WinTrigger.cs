using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    [Header("Win Config : ")]
    [SerializeField] GameObject victoryBanner;
    [SerializeField] Text finalTimeText;
    [SerializeField] Text collectedCoinText;

    [Header("Player Config : ")]
    [SerializeField] BallMovement playerBall;

    private void Start()
    {
        if (victoryBanner)
            victoryBanner.SetActive(false);

        if (!playerBall)
            playerBall = GameObject.FindObjectOfType<BallMovement>();
    }


    void SetVictory()
    {
        victoryBanner.SetActive(true);
        finalTimeText.text = "";
        collectedCoinText.text = "Final Coin : " + playerBall.coinCollected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SetVictory();
        
    }

}
