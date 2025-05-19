using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupObj_SO : ScriptableObject
{
    public string ObjName = null;
    public bool IsHeld = false;
    public bool IsUsable = false;

    public Vector3 PickUpPosition = Vector3.zero;
    public Vector3 PickUpRotation = Vector3.zero;
    public Vector3 PickUpScale = Vector3.one;
}
