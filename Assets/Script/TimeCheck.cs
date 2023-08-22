using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCheck : MonoBehaviour
{
    public GameObject objectPrefab; // 생성할 물체의 프리팹
    //public Transform objectSpawnPoint; // 물체가 생성될 위치
    public float spawnInterval = 2.0f; // 물체 생성 간격 (초 단위)
    public Text timerText; // UI Text 엘리먼트
    public Button startButton; // "Start" 버튼
    public Button finishButton;
    private Vector2 spawnPosition; // 현재 물체 생성 위치
    private float verticalOffset = 0.8f; // 물체 간격

    private bool isTiming = false;
    private float elapsedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartTiming);
        finishButton.onClick.AddListener(StopTimingAndSpawnObjects);
        spawnPosition = new Vector2(-1.0f, -3.0f); // 초기 위치 설정
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;

            // UI Text에 현재 시간 업데이트
            timerText.text = "Time: " + elapsedTime.ToString("F2");
        }
    }
    public void StartTiming()
    {
        isTiming = true;
        elapsedTime = 0.0f;
    }

    public void StopTimingAndSpawnObjects()
    {
        isTiming = false;
        int objectCount = Mathf.FloorToInt(elapsedTime / spawnInterval);

        // 물체 생성
        for (int i = 0; i < objectCount; i++)
        {
            SpawnObject();
            Debug.Log("물체생성");
        }
    }

    private void SpawnObject()
    {
        //lastSpawnPosition += Vector2.up * 20.5f; // 위로 이동
        //Instantiate(objectPrefab, objectSpawnPoint.position, Quaternion.identity);

        spawnPosition += Vector2.up * verticalOffset; // 위로 이동
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
