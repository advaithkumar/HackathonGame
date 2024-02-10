using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webShooter : MonoBehaviour
{
    Object webRef;
    public Transform firePoint;
    Vector2 direction;

    [SerializeField] Player player;


    // Start is called before the first frame update
    void Start()
    {
        webRef = Resources.Load("Web");
    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && player.getWebs() > 0)
        {
            Shoot();
            player.decreaseWebs();
        }
    }

    public void Shoot()
    {
        GameObject instantiateObject = (GameObject)Instantiate(webRef, firePoint.position, firePoint.rotation);  //creates the object and lets me refer to it
        web spawnWeb = instantiateObject.GetComponent<web>();  //get it as a bulletscript, (looked this code up)

        spawnWeb.SetDir(direction); //now I can set its damage and speed
    }
}
