using System;
using UnityEditor;
using UnityEngine;

//todo get rid of singletons after prototyping
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public int money;
}