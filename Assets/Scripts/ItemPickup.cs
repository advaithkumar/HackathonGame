using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] string itemName;
    private Vector3 offsetPos;

    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(Random.Range(-1, 2), Random.Range(-6, 4), 0);
        this.transform.position = this.transform.position + offsetPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getName()
    {
        return itemName;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
