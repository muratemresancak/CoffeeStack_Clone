using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupControl : MonoBehaviour
{
    public List<Cup> cupList;
    public DynamicBone dynamicBone;
    void Start()
    {
        dynamicBone = gameObject.GetComponent<DynamicBone>();
    }

   
    
    
    public void DynamicBonePos()
    {
        for (int i = 0; i <cupList.Count; i++)
        {
            if (i == 0)
            {
                dynamicBone.m_Root = cupList[i].gameObject.transform;
                cupList[i].transform.localPosition = Vector3.zero;
            }
            else
            {
                cupList[i].gameObject.transform.parent = cupList[i - 1].gameObject.transform;
                cupList[i].transform.localPosition = new Vector3(0, 0, 1);
            }
            cupList[i].transform.localRotation = Quaternion.identity;

            dynamicBone.SetupParticles();
        }
    }
}
