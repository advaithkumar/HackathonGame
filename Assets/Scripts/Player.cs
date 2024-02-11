using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxWebs = 10;
    [SerializeField] int webs = 10;
    [SerializeField] int keys = 0;

    [SerializeField] TextMeshProUGUI kScore;
    [SerializeField] TextMeshProUGUI kWebs;
    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        kScore.text = keys.ToString();
        kWebs.text = webs.ToString();

        healthBar.SetHealth(health);
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
        kWebs.text = webs.ToString();
    }

    public void addWebs()
    {
        webs = maxWebs;
        kWebs.text = webs.ToString();
    }

    public void addKey()
    {
        keys++;
        kScore.text = keys.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <=0)
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
                addWebs();
            else if (name.Equals("key"))
                addKey();

            item.DestroySelf();

        }

    }
}
