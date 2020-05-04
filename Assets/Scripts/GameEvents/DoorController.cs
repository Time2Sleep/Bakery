using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
    }

    private void OnDoorwayOpen()
    {
        transform.position += transform.up * 2;
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayClose;
    }
    
    private void OnDoorwayClose()
    {
        transform.position -= transform.up * 2;
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayClose;
    }
}
