using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController controller;

    [SerializeField] public Transform pickedObjectPosition;

    private GameObject pickedObject;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        controller.SimpleMove(new Vector3(hor * speed, 0, ver * speed));
        if (Input.GetMouseButtonDown(1))
        {
            if (pickedObject != null)
            {
                dropObject();
            }
        }
    }

    private void dropObject()
    {
        pickedObject.GetComponent<Collider>().enabled = true;
        pickedObject.transform.SetParent(null);
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject = null;
    }

    public void Grab(GameObject gameObject)
    {
        if (pickedObject != null)
        {
            dropObject();
        }

        pickedObject = gameObject;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.position = pickedObjectPosition.position;
        gameObject.transform.SetParent(transform);
        gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
    }
}