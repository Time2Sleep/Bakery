using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseController : MonoBehaviour
{
    private Player player;
    private Camera mainCamera;
    [SerializeField] private String tag;
    [SerializeField] private float interactionDistance;

    private bool canInteract = false;

    //debug
    public GameObject cursor;
    private Vector3 hitPoint;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        mainCamera = Camera.main;
        tag = "Interactable";
    }

    public Vector3 getHitPoint()
    {
        return hitPoint;
    }

    private void Update()
    {
        Ray interactionCursorPosition = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(interactionCursorPosition, out hit))
        {
            Debug.DrawLine(interactionCursorPosition.origin, hit.point);
            float actualDistance = Vector3.Distance(player.transform.position, hit.point);
            player.transform.LookAt(new Vector3(hit.point.x, player.transform.position.y, hit.point.z));
            if (actualDistance < interactionDistance)
            {
                hitPoint = hit.point;
                canInteract = true;
                cursor.SetActive(true);
                cursor.transform.position = hitPoint;
            }
            else
            {
                canInteract = false;
                cursor.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Debug.Log("Clicked");
            if (hit.collider.tag.Equals(tag))
            {
                Debug.Log("Tags match");
                player.Grab(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.Log(canInteract);
        }
    }
}