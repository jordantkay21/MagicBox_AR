using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public string gemColorName = "";
    public Material targetMaterial;

    private Color originalEmissionColor;

    private void Start()
    {
        originalEmissionColor = targetMaterial.GetColor("_EmissionColor");

        targetMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void ChangeEmission(bool isEmitting)
    {
        if(isEmitting == true)
        {
            targetMaterial.SetColor("_EmissionColor", originalEmissionColor);
        }
        else
        {
            targetMaterial.SetColor("_EmissionColor", Color.black);
        }
    }

}
