using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField] private Object missile;
    [SerializeField] private int ammo = 3;
    [SerializeField] float difficulty = 0;


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
        if (player != null && hitInfo.CompareTag("Player"))
        {
            difficulty = (int)player.getTravel() / 500;
            ammo = (int)difficulty + 1;
            StartCoroutine(fireMissiles());
        }
    }

    void MissileSpawn()
    {
        GameObject o = (GameObject) Instantiate(missile, transform.position, Quaternion.identity);

    }

    IEnumerator fireMissiles()
    {
        while (ammo > 0)
        {
            ammo -= 1;
            GameObject o = (GameObject)Instantiate(missile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }




    }

}
