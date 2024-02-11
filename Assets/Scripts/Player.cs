using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxWebs = 10;
    [SerializeField] int webs = 10;

    [SerializeField] TextMeshProUGUI kScore;
    [SerializeField] TextMeshProUGUI kWebs;
    [SerializeField] HealthBar healthBar;

    [SerializeField] Transform Groundcheck;  //groundcheck

    public Transform StartPos;
    float travel;

    // Start is called before the first frame update
    void Start()
    {
        kWebs.text = webs.ToString();

        healthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        travel = Mathf.Round((this.transform.position.x - StartPos.position.x) * 10);
        kScore.text = travel.ToString();


        if ((Physics2D.Linecast(transform.position, Groundcheck.position, 1 << LayerMask.NameToLayer("Ground"))) && webs <= 0)
        {
            Invoke("RestartScene", 2f);
        }

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

    public void addHealth()
    {
        if(health < 100)
        {
            health += 20;
            healthBar.SetHealth(health);
        }
    }

    public float getTravel()
    {
        return travel;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <=0)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            //Destroy(gameObject);
            RestartScene();
        }
    }

    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
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
                addHealth();

            item.DestroySelf();

        }

    }
}
