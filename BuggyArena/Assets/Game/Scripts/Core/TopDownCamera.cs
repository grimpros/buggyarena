using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float height = 10f;
    [SerializeField] private float distance = 20f;
    [SerializeField] private float angle = 45f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        if (target)
        {
            
            
        }
    }
}
