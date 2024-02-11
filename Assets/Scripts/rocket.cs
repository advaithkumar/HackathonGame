using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int damage = 10;
    Transform player;
    Rigidbody2D rb2d;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] float range = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVector = player.position - this.transform.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        rb2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage((int)damage);
            DestroySelf();
        }

    }

    public void DestroySelf()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var hitcollider in hitColliders)
        {
            rocket r = hitcollider.GetComponent<rocket>();
            if (r)
            {
                r.DestroySelf();
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
         Gizmos.DrawWireSphere(transform.position, range);   //drawing a visual sphere in the scene for us to see
    }
}
