using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBox : MonoBehaviour
{
    [Header("Config : ")]
    [SerializeField] GameObject playerGameObject;

    Vector3 playerInitPosition;

    private void Start()
    {
        if (playerGameObject)
            playerInitPosition = playerGameObject.transform.position;
        else
        {
            playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerInitPosition = playerGameObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = playerInitPosition;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
