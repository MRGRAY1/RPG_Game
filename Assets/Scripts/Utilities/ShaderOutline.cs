using System;
using UnityEngine;

public class ShaderOutline : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    private Material[] originalMaterials;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterials = rend.materials;

    }

    public void EnableOutline()
    {
        var newMats = new Material[originalMaterials.Length + 1];
        originalMaterials.CopyTo(newMats, 0);
        newMats[1] = outlineMaterial;
        rend.materials = newMats;
    }

    public void DisableOutline()
    {
        rend.materials = originalMaterials;
    }
}
