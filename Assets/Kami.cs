using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kami : MonoBehaviour
{

    [SerializeField] private Transform playa;
    [SerializeField] private Transform kami;
    public Rigidbody2D rb;
    public static GameObject Player;
   
    public LayerMask platformLayerMask;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        transform.position = playa.position;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(playa.position, Vector2.down, 10f, platformLayerMask);
        if(hit.collider != null)
        {
           
            

           transform.position = Vector3.MoveTowards(kami.position, new Vector3(kami.position.x, playa.position.y + 5f, -1f), 0.2f);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(kami.position, new Vector3(kami.position.x, playa.position.y, -1f), 0.2f);
        }
        transform.position = new Vector3(playa.position.x + 5f, kami.position.y, -1f);
       
    
    }
}
