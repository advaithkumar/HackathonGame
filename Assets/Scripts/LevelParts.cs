using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParts : MonoBehaviour
{
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] Transform position3;
    [SerializeField] Transform position4;

    [SerializeField] private Transform building;
    [SerializeField] private Transform buildingBG;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(building, position1.position, Quaternion.identity, this.transform);
        Instantiate(building, position2.position, Quaternion.identity, this.transform);

        Instantiate(buildingBG, position3.position, Quaternion.identity, this.transform);
        Instantiate(buildingBG, position4.position, Quaternion.identity, this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
