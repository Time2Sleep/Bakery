using UnityEngine;


    public class CameraFollow: MonoBehaviour
    {
        private Vector3 offset;
        [SerializeField] private Transform target;
        
        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void Update()
        {
            transform.position = target.position + offset;
        }
    }