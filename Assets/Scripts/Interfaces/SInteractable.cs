using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Stationary Interactable
/// </summary>
public class SInteractable : Interactable
{
    public override void Initialize()
    {
        base.Initialize();
        this.tag = "SInteractable";
    }
    public override void Interact()
    {
        base.Interact();
        Logger.Log("SInteractable Interaction called");
    }
}
