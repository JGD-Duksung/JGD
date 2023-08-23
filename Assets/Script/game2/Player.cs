using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 touchStartPos;

    public float moveSpeed = 1.0f;

    void Update()
    {
        // ��ġ �Է� Ȯ��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ��ġ ����
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                touchStartPos = touch.position;
            }
            // ��ġ �巡�� ��
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 dragDelta = touch.position - touchStartPos;

                // ������ ��� �� ĳ���� �̵�
                float distanceX = dragDelta.x * Time.deltaTime * moveSpeed;
                transform.Translate(distanceX, 0, 0);

                touchStartPos = touch.position;
            }
            // ��ġ ����
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Stone")
        {   
            //�� �ı�
            Destroy(collision.gameObject);
            //�÷��̾� �ı�
            Destroy(gameObject);
        }
    }
}
