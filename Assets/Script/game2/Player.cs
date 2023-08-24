using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    private bool isDragging = false;
    private Vector2 touchStartPos;

    public float moveSpeed = 1.0f;

    void Update()
    {
        // ???? ???? ????
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ???? ????
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                touchStartPos = touch.position;
            }
            // ???? ?????? ??
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 dragDelta = touch.position - touchStartPos;

                // ?????? ???? ?? ?????? ????
                float distanceX = dragDelta.x * Time.deltaTime * moveSpeed;
                transform.Translate(distanceX, 0, 0);

                touchStartPos = touch.position;
            }
            // ???? ????
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
            //?? ????
            Destroy(collision.gameObject);
            //???????? ????
            Destroy(gameObject);

            OnDie();
        }
    }

    public void OnDie()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
