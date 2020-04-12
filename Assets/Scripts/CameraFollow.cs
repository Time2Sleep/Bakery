using System.Collections;
using UnityEngine;


    public class CameraFollow: MonoBehaviour
    {
        private Vector3 offset;
        [SerializeField] private Transform target;
        [SerializeField] private float delay = 0.2f;
        
        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void Update()
        {
            StartCoroutine(Move(target.position));
        }

        IEnumerator Move(Vector3 pos)
        {
            yield return new WaitForSeconds(delay);
            transform.position = pos + offset;
        }
    }