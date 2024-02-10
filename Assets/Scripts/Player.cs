using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int webs = 10;
    [SerializeField] int keys = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getWebs()
    {
        return webs;
    }

    public void decreaseWebs()
    {
        webs--;
    }

    public void addWebs(int num)
    {
        webs += num;
    }

    public void addKey()
    {
        keys++;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log("Item");
        ItemPickup item = hitInfo.GetComponent<ItemPickup>();
        if (item != null)
        {
            string name = item.getName();
            if (name.Equals("webs"))
                addWebs(5);
            else if (name.Equals("key"))
                addKey();

            item.DestroySelf();

        }

    }
}
