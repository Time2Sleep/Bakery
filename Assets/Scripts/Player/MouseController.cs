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
        if (!MainUiFrame.instance.mouseControlsEnabled())
        {
            return;
        }

        Ray rayFromCamera = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        bool canInteract = false;
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

                canInteract = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            if (pickAndDrop.isObjectPickedUp())
            {
                pickAndDrop.dropObject(cursor.transform.position);
                cursor.SetActive(false);
            }
            else
            {
                ClickOnObject(rayHit.collider.gameObject);
            }
        }
    }

    void ClickOnObject(GameObject clickedObject)
    {
        switch (clickedObject.tag)
        {
            case "Interactable":
                cursor.SetActive(true);
                pickAndDrop.pickUpObject(clickedObject);
                break;
            case "Technics":
                clickedObject.GetComponentInParent<Technics>().interact(pickAndDrop.getPickedObject());
                break;
        }
    }
}