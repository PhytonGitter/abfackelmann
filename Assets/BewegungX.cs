using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BewegungX : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(15f, 0f), ForceMode2D.Impulse);
    }
    [SerializeField] private Transform playa;
    [SerializeField] private Transform kami;
    [SerializeField] private Transform respaaan;
    [SerializeField] private Transform Teil;
    [SerializeField] private LayerMask Player;
    [SerializeField] private float Bewegungszeug = 20f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Player)
        {
            playa.position = respaaan.position;
            kami.position = new Vector3(respaaan.position.x, respaaan.position.y, -1f);
        }
    }
    void FixedUpdate()
    {

        if (rb.position.x >= Teil.position.x)
        {
            rb.AddForce(new Vector2(-Bewegungszeug, 0f), ForceMode2D.Force);
        }
        else { rb.AddForce(new Vector2(Bewegungszeug, 0f), ForceMode2D.Force); }
    }
}
