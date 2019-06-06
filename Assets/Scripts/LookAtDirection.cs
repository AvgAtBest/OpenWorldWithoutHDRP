using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirection : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(target.forward);
    }
}
