using UnityEditor.Rendering;
using UnityEngine;
/// <summary>
/// PickUp Interactable
/// </summary>
public class PInteractable : Interactable
{
    [SerializeField]
    private GameObject SlotObj;

    private Vector3 SetPosition, SetRotation, SetScale;
    private PickUpId HelpPickUpId;


    public override void Initialize()
    {
        base.Initialize();
        this.tag = "PInteractable";
    }
    public override void Interact(Vector3 position, Vector3 rotation, Vector3 Scale, PickUpId pickUpId)
    {

        this.SetPosition = position;
        this.SetRotation = rotation;
        this.SetScale = Scale;
        this.HelpPickUpId = pickUpId;

        base.Interact();
        if (PlayerManager.IsHoldingItem)
        {
            this.DropItem();
        }
        else
        {
            this.PickUpItem();
        }
        Logger.Log("PInteractable Interaction called");
    }

    private void PickUpItem()
    {
        PlayerManager.IsHoldingItem = true;
        PlayerManager.pickUpId = this.HelpPickUpId;
        this.gameObject.transform.parent = this.SlotObj.transform;
        this.gameObject.transform.position = this.SetPosition;
        this.gameObject.transform.rotation = Quaternion.Euler(this.SetRotation);
        this.gameObject.transform.localScale = this.SetScale;
        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
        }
    }

    private void DropItem()
    {
        PlayerManager.IsHoldingItem = false;
        PlayerManager.pickUpId = PickUpId.None;
        this.gameObject.transform.parent = null;
        this.gameObject.transform.position = this.SetPosition;
        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
        }
    }
}
