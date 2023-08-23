using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Stone;

    void SpawnStone()
    {
        float randomX = Random.Range(-2f, 2f);

        if (enableSpawn)
        {
            Instantiate(Stone, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnStone", 1, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
