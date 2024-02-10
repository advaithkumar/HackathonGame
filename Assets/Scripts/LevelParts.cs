using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParts : MonoBehaviour
{
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] Transform position3;
    [SerializeField] Transform position4;

    [SerializeField] private Transform[] buildings;
    [SerializeField] private Transform[] buildingsBG;

    float randomValueX, randomValueY;
    int randomNum;
    [SerializeField] float minY, maxY;


    // Start is called before the first frame update
    void Start()
    {
        Randomize(buildings);
        Transform buildingOne = Instantiate(buildings[randomNum], position1.position, Quaternion.identity, this.transform);
        buildingOne.localScale = new Vector2(randomValueX, randomValueY);
        Debug.Log(randomNum);

        Randomize(buildings);
        Transform buildingTwo = Instantiate(buildings[randomNum], position2.position, Quaternion.identity, this.transform);
        buildingTwo.localScale = new Vector2(randomValueX, randomValueY);


        Randomize(buildingsBG);
        Transform buildingBGOne = Instantiate(buildingsBG[randomNum], position3.position, Quaternion.identity, this.transform);
        buildingBGOne.localScale = new Vector2(randomValueX, randomValueY);


        Randomize(buildingsBG);
        Transform buildingBGTwo = Instantiate(buildingsBG[randomNum], position4.position, Quaternion.identity, this.transform);
        buildingTwo.localScale = new Vector2(randomValueX, randomValueY);


    }

    public void Randomize(Transform[] array)
    {
        randomValueX = Random.Range(0.9f, 1.1f);
        randomValueY = Random.Range(minY, maxY);
        randomNum = Random.Range(0, array.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
