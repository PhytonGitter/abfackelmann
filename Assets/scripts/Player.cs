using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool rechts;
    private bool links;
    private bool nix;
    public Rigidbody2D rb;
    private float speed;
    private BoxCollider2D boxCollider2d;
    public LayerMask platformLayerMask;
    public Transform groundcheck;
   
    public Transform mittecheck;
    
   
    public Transform mittecheck2;
    
    public Transform deckecheck;
    private bool isGrounded;
    private bool Wand4;
    private bool Wand5;
    private bool decke;
    private Transform playerssss;
    
    
    private Vector2 BoxOben = new Vector2(0.1f, 0.2f);
    private Vector2 BoxMitte = new Vector2(0.2f, 0.4f);
   
    


    public LayerMask ropeLayerMask;

    public float distance = 20f;

    private LineRenderer line;
    DistanceJoint2D rope;
    SpringJoint2D seil;

    Vector2 lookDirection;

    bool checker = true;

    float aaa;
    float bbb;
    float omg;
    private float Richtung;
    private bool Jump;
    private bool Jumpchecker = true;
    private ParticleSystem p;
    private bool Luft = false;
    int i = 0;
   





    // Start is called before the first frame update
    void Start()
    {
        Jump = false;
        
        rb = GetComponent<Rigidbody2D>();
        speed = 12f;


        rope = gameObject.AddComponent<DistanceJoint2D>();
        seil = gameObject.GetComponent<SpringJoint2D>();
        
        line = GetComponent<LineRenderer>();
        p = GetComponent<ParticleSystem>();

        rope.enabled = false;
        line.enabled = false;
        seil.enabled = false;
        Richtung = 0;
        rb.drag = 2f;
        rope.enableCollision = true;
       
}

    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Richtung = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Richtung = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        { Richtung = 0; }

        isGrounded = Physics2D.OverlapBox(groundcheck.position, BoxOben, 0f, platformLayerMask);

        Wand5 = Physics2D.OverlapBox(mittecheck2.position, BoxMitte, 0f, platformLayerMask);
        Wand4 = Physics2D.OverlapBox(mittecheck.position, BoxMitte, 0f, platformLayerMask);

        decke = Physics2D.OverlapBox(deckecheck.position, BoxOben, 0f, platformLayerMask);
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.DrawLine(transform.position, lookDirection);




        if (Input.GetMouseButtonDown(0) && checker == true)
        {

            if (isGrounded == false)
            {
                if (lookDirection.y >= 0)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);


                    if (hit.collider != null)
                    {
                        omg = rb.velocity.x;
                        if (speed < 20f)
                        { speed += 5f; }

                        checker = false;
                        SetRope(hit);
                        



                        aaa = hit.point.x;
                        bbb = hit.point.y;
                        

                        // float speed2 = 8f;
                        // rb.AddForce(new Vector2(speed2 * Richtung, 0), ForceMode2D.Force);

                        if (Vector2.Distance(hit.point, rb.position) >= 20f)
                        {
                            checker = true;
                            DestroyRope();
                        }
                        
                        


                    }
                }
                else if (lookDirection.y < 0)
                {
                    checker = true;
                    DestroyRope();
                }


            }

        }

        else if (Input.GetMouseButtonDown(0) && checker == false)
        {
            checker = true;
            DestroyRope();
        }
        if (rope.enabled == false && line.enabled == false)
        {
            if (seil.enabled == false)
            {
                aaa = rb.position.x;
                bbb = rb.position.y;
            }

        }
       
        
            if (Vector2.Distance(rb.position, new Vector2(aaa, bbb)) >= 18f)
            {
            seil.enabled = false;
               
                rope.enabled = true;
                rope.connectedAnchor = new Vector2(aaa, bbb);
               


            }
        
        if (bbb < rb.position.y)
        {
            checker = true;
            DestroyRope();
        }
       

        line.SetPosition(0, new Vector2(aaa, bbb));
        line.SetPosition(1, rb.position);
    if (isGrounded == true)
     {
            Jumpchecker = true;
            if(Luft == true)
            {
                Luft = false;
                Wandstaub();
            }
        if (Input.GetKey("space"))
        {
            Wandstaub();
        }
     }
        else
        {
            
            Luft = true;
            if((Wand4 == true || Wand5 == true) && p.isPlaying == false)
            {
                Wandstaub();
            }
        }

    }
    void FixedUpdate()
    {
        if(Jumpchecker == false && isGrounded == false)
        {
            if(i>20)
            {
                Jumpchecker = true;
                i = 0;
            }
            else { i++; }

        }
        else { i = 0; }

        if (Input.GetKey("space"))
        {
            Jump = true;
        }
        else { Jump = false; }
       
        
       // else { circ.radius = radi; }
        float speady = 6f;
        if (isGrounded == true)
        {
            speed = 15f;
            if (Richtung == 0)
            {

                if (rb.velocity.x > 0f)
                {
                    rb.velocity += new Vector2(-1f,0f) ;
                    if (rb.velocity.x < 0f)
                    { rb.velocity = new Vector2(0f, 0f); }
                }
                else if (rb.velocity.x < 0f)
                {
                    rb.velocity += new Vector2(1f, 0f);
                    if (rb.velocity.x > 0f)
                    { rb.velocity = new Vector2(0f, 0f); }
                }

            }


            

            rb.AddForce(new Vector2(speady * Richtung, 0), ForceMode2D.Impulse);

            if (Jump == true)
            {

                float jumpVelocity = 25f;
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                
            }
        }
        else
        {
            if (speed > 15f)
            {
                float speed2 = 5f;
                rb.AddForce(new Vector2(speed2 * Richtung, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(speady * Richtung, 0), ForceMode2D.Impulse);
            }

        }
        if (Wand4)
        {

            if (rb.velocity.x >= 0)
            {
                rb.velocity = new Vector2(0f, -3f);


            }
            if (Jump == true)
            {
                speed = 20f;
                rb.velocity = new Vector2(-20f, 20f);

            }
            // circ.radius = 0f;



        }
        //  else { circ.radius = radi; }
        if (Wand5)
        {

            if (rb.velocity.x <= 0f)
            {
                rb.velocity = new Vector2(0f, -3f);


            }
            if (Jump == true)
            {
                speed = 20f;
                rb.velocity = new Vector2(20f, 20f);

            }
            //  circ.radius = 0f;


        }









        if (Wand4 == true || Wand5 == true || isGrounded == true || decke == true)
        {
            checker = true;
            DestroyRope();
        }
        if (rope.enabled == true && line.enabled == true)
        {
            if (rb.velocity.x > 0)
            {
                float speed2 = 4f;
                rb.AddForce(new Vector2(speed2 * Richtung, 0), ForceMode2D.Impulse);
            }
            if (rb.velocity.x < 0)
            {
                float speed2 = -4f;
                rb.AddForce(new Vector2(-speed2 * Richtung, 0), ForceMode2D.Impulse);
            }
        }
        if ((rope.enabled == true && line.enabled == true) ||(seil.enabled == true && line.enabled == true))
        {
            if (Jump == true && Jumpchecker == true)
            {
                Jumpchecker = false;
                checker = true;
                DestroyRope();
                speed += 5f;
                if (rb.velocity.x > 0 && rb.velocity.y > 0)
                {

                    rb.velocity += new Vector2(5f, 10f);
                }
                else if (rb.velocity.x < 0 && rb.velocity.y > 0)
                {

                    rb.velocity += new Vector2(-5f, 10f);
                }
            }
            if(Input.GetKey(KeyCode.R))
            {
                seil.enabled = false;
                rope.enabled = true;
                rope.connectedAnchor = new Vector2(aaa, bbb);
                rope.distance = Vector2.Distance(rb.position, new Vector2(aaa, bbb));


            }
        }
        if (rb.velocity.x > speed)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (rb.velocity.x < -speed)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }



    void SetRope(RaycastHit2D hit)
    {
        seil.enabled = true;
        seil.connectedAnchor = hit.point;

        line.enabled = true;
        line.SetPosition(1, hit.point);
    }
    

    void DestroyRope()
    {
        rope.enabled = false;
        line.enabled = false;
        seil.enabled = false;
        aaa = rb.position.x;
        bbb = rb.position.y;
       
    }
    void Wandstaub()
    {
        if (p.isPlaying)
        { return; }
        p.Play();
    }
 }

    










    

