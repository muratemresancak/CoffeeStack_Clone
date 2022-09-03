using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CupType 
{
    FirstCup,
    SecondCup,
    ThirdCup
}
public class Cup : MonoBehaviour
{
    [Header("CUP LID")]
    public GameObject lid;
    
    [Header("CUP SLEEVE")]
    public GameObject sleeve;
    
    [Header("SECOND CUP MESHES")]
    public Mesh secondCupMesh;
    public Mesh secondCupLidMesh;
    public Mesh secondCupSleeveMesh;
    
    [Header("THIRD CUP MESHES")]
    public Mesh thirdCupMesh;
    public Mesh thirdCupLidMesh;
    public Mesh thirdCupSleeveMesh;
    
    private bool isChanged = false;
    
    
    public bool isCollcet;
    public CupControl cupControl;

    public CupType cupType;
  
    private void OnTriggerEnter(Collider other)
    {
        Cup cup = other.GetComponent<Cup>();
        Obstacle obstacle = other.GetComponent<Obstacle>();
        Gate gate = other.GetComponent<Gate>();
        
        if (cup&&!cup.isCollcet)
        {
            cup.isCollcet = true;
            cup.gameObject.transform.parent = gameObject.transform;
            cupControl.cupList.Add(cup);
            for (int i = 0; i < cup.transform.childCount; i++)
            {
                if (cup.transform.childCount > 0) 
                {
                    cupControl.dynamicBone.m_Exclusions.Add(cup.transform.GetChild(i));
                }
            }
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

        if (gate)
        {
            if (gate.gateType == GateType.UpgradeGate) 
            {
                ChangeCup();
                isChanged = false;
            }

            if (gate.gateType == GateType.LidGate) 
            {
                lid.SetActive(true);
            }
            if (gate.gateType == GateType.SleeveGate) 
            {
                sleeve.SetActive(true);
            }
            
        }
    }

    public void ChangeCup()
    {
        if (this.cupType == CupType.FirstCup && !isChanged)
        {
            isChanged = true;
            this.cupType = CupType.SecondCup;
            SecondCup();
            gameObject.GetComponent<MeshRenderer>().material.color=Color.blue;
        }
        

        if (this.cupType == CupType.SecondCup && !isChanged)
        {
            isChanged = true;
            this.cupType = CupType.ThirdCup;
            ThirdCup();
            gameObject.GetComponent<MeshRenderer>().material.color=Color.green;
            
        }

        if (this.cupType == CupType.ThirdCup && !isChanged)
        {
            isChanged = true;
            this.cupType = CupType.ThirdCup;
        }
        
    }

    public void SecondCup()
    {
        gameObject.GetComponent<MeshFilter>().mesh = secondCupMesh;
        lid.GetComponent<MeshFilter>().mesh = secondCupLidMesh;
        sleeve.GetComponent<MeshFilter>().mesh = secondCupSleeveMesh;
    }

    public void ThirdCup()
    {
        gameObject.GetComponent<MeshFilter>().mesh = thirdCupMesh;
        lid.GetComponent<MeshFilter>().mesh = thirdCupLidMesh;
        sleeve.GetComponent<MeshFilter>().mesh = thirdCupSleeveMesh;
    }



    


}
