using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    public static PickAndDrop instance;
    private GameObject pickedObject;
    [SerializeField] private Transform pickedObjectPos;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void pickUpObject(GameObject objectToPickUp)
    {
        pickedObject = objectToPickUp;
        pickedObject.transform.SetParent(transform);
        pickedObject.transform.position = pickedObjectPos.position;
        pickedObject.GetComponent<Collider>().enabled = false;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void dropObject(Vector3 newPos)
    {
        if (isObjectPickedUp())
        {
            pickedObject.transform.SetParent(null);
            pickedObject.transform.position = newPos;
            pickedObject.GetComponent<Collider>().enabled = true;
            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject = null;
        }
    }

    public bool isObjectPickedUp()
    {
        return pickedObject != null;
    }

    public GameItem getPickedObject()
    {
        return pickedObject != null ? pickedObject.GetComponent<GameItem>() : null;
    }
}