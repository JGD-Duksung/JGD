using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour

{

    private float Timer;                            //화면에 보여줄 실수형 변수

    private Text text;                               //UI Text

    //private DelayTimeMain DelayCount;      //이전의 코루틴 설명에 설명된 딜레이 값.





    // Start is called before the first frame update

    void Start()

    {

        //코드 참조

       //DelayCount = GameObject.Find("Canvas").GetComponent<DelayTimeMain>();

        //참조된 텍스트 UI 컴포넌트

        text = this.gameObject.GetComponent<Text>();

    }



    // Update is called once per frame

    void Update()

    {

        //if (DelayCount.DelayCount == 0)    //딜레이 값이 0이면

        {

            //실시간 Time.deltaTime 초기화.

            Timer = Timer + Time.deltaTime;

            //실수형 변수 첫번째 자리까지 포맷하여 UI Text 로 가시화

            text.text = string.Format("", Timer);



        }



    }

}