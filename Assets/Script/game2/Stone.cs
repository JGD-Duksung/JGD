using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    //움직일 속도 지정
    public float moveSpeed = 2f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //움직일 거리 계산
        float distanceY = moveSpeed * Time.deltaTime;

        //움직임 반영
        transform.Translate(0, -distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
