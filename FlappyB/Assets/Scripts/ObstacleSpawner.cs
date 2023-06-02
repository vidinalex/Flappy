using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    private float spawnTime, timer, offset;
    private void Start()
    {
        spawnTime = GameData.Default.spawnTime * Mathf.Pow(GameData.Default.spawnTimeMult, PlayerPrefs.GetInt("difficulty", 0) + 1);
        offset = GameData.Default.offset;
    }

    private void Update()
    {
        if (timer > spawnTime)
        {
            GameObject tempObstacle = Instantiate(obstacle);
            tempObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-offset, offset), 0);
            Destroy(tempObstacle, 15f);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
