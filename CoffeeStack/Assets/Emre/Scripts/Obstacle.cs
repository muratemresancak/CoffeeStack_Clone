using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isTaked;
    private Quaternion rot;
    private Vector3 targetRot;
    private bool xxx=false;
    void Start()
    {
        rot = gameObject.transform.localRotation;
        targetRot = new Vector3(0, 0, 0);

    }

   
    void Update()
    {
        // if (isTaked)
        // {
        //     StartCoroutine(TakeCoffee());
        // }
    }

    public IEnumerator TakeCoffee()
    {
        //if (!xxx)
       // {
          //  xxx = true;
            float time = 0;
            while (time<1)
            {
                gameObject.transform.localRotation = Quaternion.Lerp(rot, Quaternion.Euler(targetRot), time);
                time += Time.deltaTime; 
                yield return new WaitForEndOfFrame(); 
            }
       // }
        
        
    }
}
