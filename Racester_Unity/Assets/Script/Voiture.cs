using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiture : MonoBehaviour
{
    public float Speed;
    public Vector3 position_checkpoint;
    private Vector3 position_start;
    public List<Vector3> list_checkpoint;

    public float timer;
    public float timer_up;
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
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 1, 0));
        }
        else if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.Q)))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, -1, 0));
        }
        else if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Z)))
        {
            //peed = 1;
            timer_up += Time.deltaTime;
            if (Speed < 50)
            {
                Speed = timer_up * 10;
            }
            r.AddForce(GetComponent<Transform>().forward * (Speed));
        }
        //if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.Z)))
        else if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
            r.AddForce(-GetComponent<Transform>().forward * Speed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            r.AddForce(new Vector3(0, 500, 0));
        }
        else if (Input.GetKey(KeyCode.Backspace))
        {
            transform.position = position_checkpoint;
            Speed = 0;
            timer_up = 0;
      
        }
        else if (Input.GetKey(KeyCode.Delete))
        {
            transform.position = position_start;
            timer = 0;
        }
        else if(true)
        {
            
            if (Speed > 0) {
                timer_up -= Time.deltaTime;
                Speed = timer_up * 10;
                //r.AddForce(GetComponent<Transform>().forward * Speed);
            }
            else
            {
                Speed = 0;
            }
        }
    }
} 
