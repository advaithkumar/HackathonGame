using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField] private Object missile;
    [SerializeField] private int ammo = 3;

    bool startShoot = true;

/*    public Transform[] spawners;
    private Transform spawnPoint;
    public GameObject[] enemies;
    private GameObject enemy;
*/
    // Start is called before the first frame update
    void Start()
    {
        missile = Resources.Load("MissileOne");
    }

    // Update is called once per frame
    void Update()
    {
        if(startShoot)
        {
            if(ammo > 0)
            {
                StartCoroutine(fireMissiles());
                ammo--;
            }
                
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            startShoot = true;
            StartCoroutine(fireMissiles());
        }
    }

    void MissileSpawn()
    {
        GameObject o = (GameObject) Instantiate(missile, transform.position, Quaternion.identity);

    }

    IEnumerator fireMissiles()
    {
        /*        while(ammo > 0)
                {
                    ammo -= 1;
                    GameObject o = (GameObject)Instantiate(missile, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);

                    Debug.Log("missile");
                }
        */
        while (startShoot == true)
        {
            startShoot = false;
            if(ammo > 0)
            {
                GameObject o = (GameObject)Instantiate(missile, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                ammo--;
            }
            startShoot = true;


        }


    }

/*    odds = Random.Range(1, 11); //gets a random odds

        *//*        if (odds <= 7) //70 percent I think, then spawn the small enemy
                    enemy = enemies[0];
                else
                    enemy = enemies[1]; //else spawn the big enemy for 20 percent (could be different odds, not sure)*//*
        enemy = enemies[0];
        int i = Random.Range(0, spawners.Length);
    spawnPoint = spawners[i];*/
}
