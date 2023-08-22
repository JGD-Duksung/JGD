using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        //invokeRepeating(함수이름, 초기지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //미사일프리팹, 런쳐포지션, 방향값 없음
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
