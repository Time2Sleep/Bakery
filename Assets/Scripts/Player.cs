using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController controller;
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
        controller.SimpleMove(new Vector3(hor*speed,0,ver*speed));
        
        if ((Mathf.Abs(hor) + Mathf.Abs(ver)) >= 0.2f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x * ver, 0, Camera.main.transform.forward.y * -hor));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Grab();
        }

    }

    void Grab()
    {
        Debug.Log("Trying to hit object to grab");
        RaycastHit objectHit;
        if (Physics.Raycast(transform.position, transform.forward-transform.up, out objectHit, 5)) {
            if (objectHit.collider.gameObject.GetComponent<Item>() != null)
            {
                objectHit.transform.position = transform.position + transform.right+transform.up;
                objectHit.transform.SetParent(transform);
                objectHit.transform.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        
    }
}
