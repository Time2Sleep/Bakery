using System;
using UnityEditor;
using UnityEngine;

public class UiMenu : MonoBehaviour
{
    public GameObject[] canvasObjects;
    public bool enableCharacterControls;
    public bool enableMouseControls;
    public Action<bool> menuState;

    public virtual void focus()
    {
        updateState(true);
        menuState?.Invoke(true);
    }

    public void disable()
    {
        updateState(false);
        menuState?.Invoke(false);
    }

    private void updateState(bool state)
    {
        foreach (var canvasObject in canvasObjects)
        {
            canvasObject.SetActive(state);
        }
    }
}