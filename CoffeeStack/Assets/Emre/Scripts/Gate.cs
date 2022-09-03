using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType
{
    UpgradeGate,
    LidGate,
    SleeveGate
}
public class Gate : MonoBehaviour
{
    public GateType gateType;
}
