using System;
using UnityEngine;

public class MainUiFrame : MonoBehaviour
{
    public static MainUiFrame instance;

    public UiMenu currentMenu;
    public UiMenu defaultMenu;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        currentMenu = defaultMenu;
    }

    public void focusOn(UiMenu uiMenu)
    {
        currentMenu.disable();
        currentMenu = uiMenu;
        currentMenu.focus();
    }

    public void resetToDefault()
    {
        focusOn(defaultMenu);
    }

    //todo move to gameStateController or smth
    public bool characterControlsEnabled()
    {
        return currentMenu.enableCharacterControls;
    }

    public bool mouseControlsEnabled()
    {
        return currentMenu.enableMouseControls;
    }
}