using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isTaken;
    private Quaternion rot;
    private Vector3 targetRot;
   
    void Start()
    {
        rot = gameObject.transform.localRotation;
        targetRot = new Vector3(0, 0, 0);
    }

   
    

    public IEnumerator TakeCoffee()
    {
        float time = 0; 
        while (time<1) 
        { 
            gameObject.transform.localRotation = Quaternion.Lerp(rot, Quaternion.Euler(targetRot), time); 
            time += Time.deltaTime; 
            yield return new WaitForEndOfFrame(); 
        }
    }
}
