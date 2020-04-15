using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    private bool isMouseOver = false;
    private Renderer rend;
    public ItemInfo itemInfo;
    private Color baseColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.GetColor("_Color");
    }

    public void HighlightObject()
    {
        if (!isMouseOver)
        {
            isMouseOver = true;
            foreach (Material rendMaterial in rend.materials)
            {
                rendMaterial.SetColor("_Color", Color.green);
            }
             
        }
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        foreach (Material rendMaterial in rend.materials)
        {
            rendMaterial.SetColor("_Color", baseColor); 
        }
    }

    public void selfDestroy()
    {
        Destroy(gameObject);
    }

    public Item asItem()
    {
        return new Item(this);
    }
}