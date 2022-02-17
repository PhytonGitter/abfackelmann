using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regigigas : MonoBehaviour
{
    [SerializeField] private Transform playa;
    [SerializeField] private Transform kami;
    [SerializeField] private Transform respaaan;

    void OnTriggerEnter2D(Collider2D other)
    {
        playa.position = respaaan.position;
        kami.position = new Vector3(respaaan.position.x,respaaan.position.y,-1f);
        
    }
}
