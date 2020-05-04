using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    [SerializeField] private Animator charMeshAnimator;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private MainUiFrame _mainUiFrame;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        charMeshAnimator.enabled = false;
        _mainUiFrame = MainUiFrame.instance;
    }

    void Update()
    {
        if (!_mainUiFrame.characterControlsEnabled())
        {
            return;
        }

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
        {
            if (_mainUiFrame.currentMenu is MarketMenu)
            {
                _mainUiFrame.resetToDefault();
            }

            charMeshAnimator.enabled = true;
            transform.forward = _inputs;
        }
        else
        {
            charMeshAnimator.enabled = false;
        }
    }


    void FixedUpdate()
    {
        if (!_mainUiFrame.characterControlsEnabled())
        {
            return;
        }

        _body.MovePosition(_body.position + _inputs * (Speed * Time.fixedDeltaTime));
    }
}