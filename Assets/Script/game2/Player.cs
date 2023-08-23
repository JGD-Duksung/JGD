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
        // 터치 입력 확인
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 터치 시작
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                touchStartPos = touch.position;
            }
            // 터치 드래그 중
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 dragDelta = touch.position - touchStartPos;

                // 움직임 계산 및 캐릭터 이동
                float distanceX = dragDelta.x * Time.deltaTime * moveSpeed;
                transform.Translate(distanceX, 0, 0);

                touchStartPos = touch.position;
            }
            // 터치 종료
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
            //적 파괴
            Destroy(collision.gameObject);
            //플레이어 파괴
            Destroy(gameObject);
        }
    }
}
