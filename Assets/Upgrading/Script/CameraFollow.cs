using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Config : ")]
    [SerializeField] GameObject followObject;

    Vector3 offset;

    private void Start()
    {
        if (!followObject)
            followObject = GameObject.FindGameObjectWithTag("Player");
        
        offset = followObject.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = followObject.transform.position - offset;
    }
}
