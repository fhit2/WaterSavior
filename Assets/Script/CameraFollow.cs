using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
<<<<<<< HEAD
    private Vector3 offset = new Vector3(0f, 3f, -10f);
=======
    private Vector3 offset = new Vector3(0f, 0f, -10f);
>>>>>>> 17943a0f9a85a203b192ad6db4644cb8f83e8b5c
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
    }
}
