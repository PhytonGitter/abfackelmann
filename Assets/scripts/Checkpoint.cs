using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private Rigidbody2D checkpoint;
    [SerializeField] private Transform respaaan;

    void OnTriggerEnter2D(Collider2D other)
    {
        respaaan.position = checkpoint.position;
       

    }
}
