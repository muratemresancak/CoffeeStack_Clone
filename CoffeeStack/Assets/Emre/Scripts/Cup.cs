using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public bool isCollcet;
    public CupControl cupControl;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Cup cup = other.GetComponent<Cup>();
        Obstacle obstacle = other.GetComponent<Obstacle>();
        
        if (cup&&!cup.isCollcet)
        {
            cup.isCollcet = true;
            cup.gameObject.transform.parent = gameObject.transform;
            cupControl.cupList.Add(cup);
            cupControl.DynamicBonePos();
        }

        if (obstacle&&!obstacle.isTaked)
        {
            cupControl.cupList.Remove(this);
            gameObject.transform.parent = obstacle.gameObject.transform;
            obstacle.isTaked = true;
            StartCoroutine(obstacle.TakeCoffee());
            cupControl.DynamicBonePos();
        }
    }

   
}
