using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float actualSpeed;
    private void Start()
    {
        actualSpeed = GameData.Default.obstacleSpeed * Mathf.Pow(GameData.Default.speedMult, PlayerPrefs.GetInt("difficulty", 0) + 1);
    }
    void Update()
    {
        transform.position += Vector3.left * actualSpeed * Time.deltaTime;
    }
}
