using UnityEngine;

public class PlayerInteractionOutline : MonoBehaviour
{
    [SerializeField]
    private float interactionDistance;
    private ShaderOutline lastOutline;
    private readonly string[] interactableTags = { "SInteractable", "PInteractable" };
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            foreach (var tag in interactableTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    ShaderOutline currentOutline = hit.collider.GetComponent<ShaderOutline>();
                    if (currentOutline != null)
                    {
                        if (currentOutline != lastOutline)
                        {
                            if (lastOutline != null) lastOutline.DisableOutline();
                            currentOutline.EnableOutline();
                            lastOutline = currentOutline;
                        }
                    }
                }
            }
        }
        else if (lastOutline != null)
        {
            lastOutline.DisableOutline();
            lastOutline = null;
        }
    }
}
