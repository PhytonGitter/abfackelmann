using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neu : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*10000, rb.velocity.y,0) * Time.deltaTime;
    }
}
