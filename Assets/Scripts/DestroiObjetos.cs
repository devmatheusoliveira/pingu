using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjetos : MonoBehaviour
{
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
