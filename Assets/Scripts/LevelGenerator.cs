using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform LevelPart_Start;
    [SerializeField] private Transform levelPart_1;

    private Vector3 lastEndPosition;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 75f;
    [SerializeField] Transform player;

    private void Awake()
    {
        lastEndPosition = LevelPart_Start.Find("EndPosition").position;

        SpawnLevelPart();

        /*Transform lastLevelPartTransform;
        lastLevelPartTransform = SpawnLevelPart(LevelPart_Start.Find("EndPosition").position);

        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);*/

        int startSpawnParts = 2;
        for (int i = 0; i < startSpawnParts; i++)
            SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }
}
