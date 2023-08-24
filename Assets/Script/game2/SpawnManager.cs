//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnManager : MonoBehaviour
//{
//    public bool enableSpawn = false;
//    public GameObject enemy1;
//    public GameObject enemy2;
//    public GameObject enemy3;

//    void SpawnEnemy()
//    {
//        float randomX = Random.Range(-2f, 2f);

//        if (enableSpawn)
//        {
//            Instantiate(enemy1, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
//            Instantiate(enemy2, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
//            Instantiate(enemy3, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        InvokeRepeating("SpawnEnemy", 1, 0.8f);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    void SpawnEnemy()
    {
        if (enableSpawn)
        {
            float randomX = Random.Range(-2f, 2f);
            int randomEnemy = Random.Range(1, 4); // 랜덤으로 1, 2, 3 중 하나를 선택

            GameObject enemyToSpawn = null;
            switch (randomEnemy)
            {
                case 1:
                    enemyToSpawn = enemy1;
                    break;
                case 2:
                    enemyToSpawn = enemy2;
                    break;
                case 3:
                    enemyToSpawn = enemy3;
                    break;
            }

            if (enemyToSpawn != null)
            {
                Instantiate(enemyToSpawn, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
            }
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
