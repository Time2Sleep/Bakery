using UnityEngine;


    public class PlayerMovement: MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

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
        }
    }