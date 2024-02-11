using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web : MonoBehaviour
{
    [SerializeField] float speed = 1;
    //[SerializeField] float damage = 100;
    [SerializeField] float destroyTime = 2f;

    Rigidbody2D rb2d;
    public Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(dir * speed, ForceMode2D.Impulse);
        Invoke("DestroySelf", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //rb2d.velocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        rocket rocket = hitInfo.GetComponent<rocket>();
        if (rocket != null)
        {
            rocket.DestroySelf();
            DestroySelf();
        }

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetDir(Vector2 direction)
    {
        this.dir = direction;
    }
}
