using System;
using UnityEditor;
using UnityEngine;

public class UiMenu : MonoBehaviour
{
    public GameObject[] canvasObjects;
    public bool enableCharacterControls;
    public bool enableMouseControls;

    public void focus()
    {
        updateState(true);
    }

    public void disable()
    {
        updateState(false);
    }

    private void updateState(bool state)
    {
        foreach (var canvasObject in canvasObjects)
        {
            canvasObject.SetActive(state);
        }
    }
}