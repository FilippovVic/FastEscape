using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPref;
    private float SpawnTime;
    public float Range;
    public float[] SpawnPoints;

    public float _timeBeforeStart;

    public void Update()
    {
        if (_timeBeforeStart <= 0)
        {
            SpawnTime = Random.Range(1, Range);
            int random = Random.Range(0, SpawnPoints.Length);
            Instantiate(EnemyPref[Random.Range(0, 3)], new Vector2(SpawnPoints[random], transform.position.y), Quaternion.identity);
            _timeBeforeStart = SpawnTime;
        }
        else
        {
            _timeBeforeStart -= Time.deltaTime;
        }
    }
}