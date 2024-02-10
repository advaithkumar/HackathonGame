using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField] private Object missile;

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
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            MissileSpawn();
        }
    }

    void MissileSpawn()
    {
        GameObject o = (GameObject) Instantiate(missile, transform.position, Quaternion.identity);

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
