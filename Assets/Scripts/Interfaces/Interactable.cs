using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Initialize()
    {
    }
    public virtual void Interact()
    {
        Logger.Log("Interactable Interaction called");
    }
    public virtual void Interact(Vector3 position, Vector3 rotation, Vector3 Scale, PickUpId pickUpId)
    {
        Logger.Log("Interactable Interaction called");
    }

}