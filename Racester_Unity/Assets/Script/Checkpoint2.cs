﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    private Voiture voiture;
    private bool checkpoint_valide;
    public float test;

    // Start is called before the first frame update
    void Start()
    {
        voiture = GameObject.FindGameObjectWithTag("Voiture").GetComponent<Voiture>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        //test = 15;
        if (other.gameObject.tag == "Voiture"){
            checkpoint_valide = false;
            foreach(Vector3 chekpoint in voiture.list_checkpoint)
            {
                if(transform.position == chekpoint)
                {
                    checkpoint_valide = true;
                }
            }
            if (!checkpoint_valide)
            {
                voiture.position_checkpoint = transform.position;
                voiture.list_checkpoint.Add(transform.position);
            }
        }
    }
}
