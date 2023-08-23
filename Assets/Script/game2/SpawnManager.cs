using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject enemy;

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);

        if (enableSpawn)
        {
            Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
