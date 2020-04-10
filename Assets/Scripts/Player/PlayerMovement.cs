using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement: MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private Animator charMesh;

        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }
        
        void Update()
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            controller.SimpleMove(new Vector3(hor * speed, 0, ver * speed));
            if (Math.Abs(hor) + Math.Abs(ver) > 0.2)
            {
                charMesh.enabled = true;
            }
            else
            {
                charMesh.enabled = false;
            }
        }
    }