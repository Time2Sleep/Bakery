using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    private GameObject pickedObject;
    [SerializeField] private Transform pickedObjectPos;


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
            pickedObject.transform.position = newPos + Vector3.up / 4f;
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
        return pickedObject.GetComponent<GameItem>();
    }
}