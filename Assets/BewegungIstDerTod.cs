using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BewegungIstDerTod : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D b;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        b = GetComponent<BoxCollider2D>();
        rb.AddForce(new Vector2(0f, -10f), ForceMode2D.Impulse);
       
    }
    [SerializeField] private Transform playa;
    [SerializeField] private Transform kami;
    [SerializeField] private Transform respaaan;
    [SerializeField] private Transform Teil;
    [SerializeField] private LayerMask Player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playa.position = respaaan.position;
            kami.position = new Vector3(respaaan.position.x, respaaan.position.y, -1f);
        }
      
    }
    void FixedUpdate()
    {

        if(rb.position.y >= Teil.position.y)
        {
            rb.AddForce(new Vector2(0f,-20f), ForceMode2D.Force);
        }
        else { rb.AddForce(new Vector2(0f, 20f), ForceMode2D.Force); }
    }

    
   
}
