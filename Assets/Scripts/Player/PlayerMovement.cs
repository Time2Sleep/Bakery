using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    [SerializeField] private Animator charMeshAnimator;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        charMeshAnimator.enabled = false;
    }

    void Update()
    {
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
        {
            charMeshAnimator.enabled = true;
            transform.forward = _inputs;
        }
        else
        {
            Debug.Log("Kek");
            charMeshAnimator.enabled = false;
        }
            

       
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
}