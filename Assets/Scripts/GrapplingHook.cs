using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;

    private DistanceJoint2D joint;
    private Vector3 grapplePoint;
    private Rigidbody2D rb2d;

    [SerializeField] float grappleSpeed = 3f;
    [SerializeField] float swingSpeed = 3f;

    Vector2 direction;

    [SerializeField] Transform Hookpoint;

    public Rope AnimRope;
    SpriteRenderer sp;
    Animator anim;

    Vector3 gp;
    bool flipped = false;
    bool swinging = true;

    // Start is called before the first frame update
    void Start()
    {
        joint = this.gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
        rb2d = this.GetComponent<Rigidbody2D>();
        sp = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, grappleLayer);
            Debug.DrawRay(transform.position, direction, Color.red);


            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;

                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                //joint.distance = grappleLength;

                rope.sortingLayerName = "Rope";
                rope.enabled = true;
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, Hookpoint.position);

                //AnimRope.StartRopeAnim(grapplePoint);

            }
/*            if(transform.position.x - grapplePoint.x < 0)
            {
                if (!sp.flipX)
                    sp.flipX = true;
            }
            else if(transform.position.x - grapplePoint.x > 0)
            {
                if (sp.flipX)
                    sp.flipX = false;
            }*/
            
        }
        //Debug.Log(rb2d.velocity);
        if (rb2d.velocity.x > 0)
        {
            if(!flipped)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                flipped = true;
            }

            /*if(!sp.flipX)
                sp.flipX = true;*/
        }
        else if(rb2d.velocity.x < 0)
        {
            if(flipped)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                flipped = false;
            }

            /* if (sp.flipX)
                 sp.flipX = false;*/
        }

        //anim.SetFloat("YVelocity", rb2d.velocity.y);



        if (joint.enabled == true)
        {
            // Set the target distance for the DistanceJoint2D
            float distance = Vector2.Distance(transform.position, grapplePoint);

            // Gradually adjust the DistanceJoint2D distance over time
            //joint.distance = Mathf.MoveTowards(distance, 0f, grappleSpeed * Time.deltaTime);
            joint.distance = distance;

            gp = grapplePoint - transform.position;

            rb2d.SetRotation(Mathf.Atan2(gp.y, gp.x) * Mathf.Rad2Deg - 90);

        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        if(rope.enabled == true)
        {
            rope.SetPosition(1, Hookpoint.position);

            if (Input.GetKey("w"))
            {
                Vector2 grappleDir = (grapplePoint - transform.position).normalized;

                // Add force to the player's Rigidbody2D
                //this.GetComponent<Rigidbody2D>().AddForce(grappleDir * grappleSpeed);
                rb2d.velocity = grappleDir * grappleSpeed;

            }

            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * swingSpeed);
            }
            else if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * swingSpeed);
            }

            if(swinging == false)
            {
                //anim.SetBool("Swinging", true);
                swinging = true;
            }

        }
        else
        {
            if (swinging == true)
            {
                //anim.SetBool("Swinging", false);
                swinging = false;
            }

            rb2d.SetRotation(0);
        }

        if (joint.distance < 1)
        {
            rope.enabled = false;
            joint.enabled = false;
        }

        Vector3 distanceVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        //rb2d.SetRotation(angle);


        //Debug.Log(rb2d.velocity);
    }
}
