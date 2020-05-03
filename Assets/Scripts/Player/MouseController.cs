using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private float interactionDistance = 3f;
    private Camera _camera;
    private PickAndDrop pickAndDrop;

    private void Start()
    {
        _camera = Camera.main;
        cursor.SetActive(false);
        pickAndDrop = GetComponent<PickAndDrop>();
    }

    private void Update()
    {
        Ray rayFromCamera = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(rayFromCamera, out rayHit))
        {
            float distance = Vector3.Distance(transform.position, rayHit.point);
            transform.LookAt(new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z));
            if (interactionDistance > distance)
            {
                cursor.transform.position = rayHit.point + new Vector3(0f, 0.1f, 0f);
                if (rayHit.collider.tag.Equals("Interactable"))
                {
                    rayHit.collider.GetComponent<GameItem>().HighlightObject();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    ClickOnObject(rayHit.collider.gameObject);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            pickAndDrop.dropObject(cursor.transform.position);
            cursor.SetActive(false);
        }
    }

    void ClickOnObject(GameObject clickedObject)
    {
        switch (clickedObject.tag)
        {
            case "Interactable":
                cursor.SetActive(true);
                if (pickAndDrop.isObjectPickedUp())
                {
                    pickAndDrop.dropObject(clickedObject.transform.position);
                }

                pickAndDrop.pickUpObject(clickedObject);
                break;
            case "Technics":
                clickedObject.GetComponentInParent<Technics>().interact(pickAndDrop.getPickedObject());
                break;
        }
    }
}