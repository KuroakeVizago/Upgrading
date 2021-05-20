using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [Header("UpDown Animation")]
    [SerializeField] float amplitude = 1;
    [SerializeField] float speedAnimation = 1;

    [Header("Rotate Animation")]
    [SerializeField] float rotateSpeed;
    private float YValue;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotateAnimation();

        UpDownAnimation();
    }

	private void RotateAnimation()
	{
        YValue += Time.deltaTime * rotateSpeed;

        transform.rotation = Quaternion.Euler(Vector3.up * YValue);
	}

	private void UpDownAnimation()
	{
        transform.position = Vector3.up * Mathf.Sin(Time.time * speedAnimation) * amplitude + startPosition;
	}
}
