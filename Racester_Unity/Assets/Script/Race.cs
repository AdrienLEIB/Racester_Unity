using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    public float Speed;
    public float timer;
    public Vector3 position_checkpoint;
    private Vector3 position_start;

    // Start is called before the first frame update
    void Start()
    {
        position_checkpoint = transform.position;
        position_start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Rigidbody r = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            r.AddForce(GetComponent<Transform>().forward * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            r.AddForce(-GetComponent<Transform>().forward * Speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            r.AddForce(new Vector3(0, 500, 0));
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            transform.position = position_checkpoint;

        }
        if (Input.GetKey(KeyCode.Delete))
        {
            transform.position = position_start;
            timer = 0;
        }
    }
}
