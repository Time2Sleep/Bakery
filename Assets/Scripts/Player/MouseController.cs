using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private float interactionDistance = 3f;
    private Camera camera;
    private PickAndDrop pickAndDrop;

    private void Start()
    {
        camera = Camera.main;
        cursor.SetActive(false);
        pickAndDrop = GetComponent<PickAndDrop>();
    }

    private void Update()
    {
        Ray rayFromCamera = camera.ScreenPointToRay(Input.mousePosition);
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
                    if (Input.GetMouseButtonDown(0))
                    {
                        cursor.SetActive(true);
                        if (pickAndDrop.isObjectPickedUp())
                        {
                            pickAndDrop.dropObject(rayHit.point);
                        }

                        pickAndDrop.pickUpObject(rayHit.collider.gameObject);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            pickAndDrop.dropObject(cursor.transform.position);
            cursor.SetActive(false);
        }
    }
}