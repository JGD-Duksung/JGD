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
        //Y���̵�
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //���� �̺�Ʈ ����
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //ȭ������� ������ ȣ��
    private void OnBecameInvisible()
    {
        //�̻��� ȭ�� ������ ������ ��
        Destroy(gameObject);
    }
}