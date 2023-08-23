using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Y축이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //폭발 이벤트 생성
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //화면밖으로 나가면 호출
    private void OnBecameInvisible()
    {
        //미사일 화면 밖으로 나갔을 때
        Destroy(gameObject);
    }
}
