using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour

{

    private float Timer;                            //ȭ�鿡 ������ �Ǽ��� ����

    private Text text;                               //UI Text

    //private DelayTimeMain DelayCount;      //������ �ڷ�ƾ ���� ����� ������ ��.





    // Start is called before the first frame update

    void Start()

    {

        //�ڵ� ����

       //DelayCount = GameObject.Find("Canvas").GetComponent<DelayTimeMain>();

        //������ �ؽ�Ʈ UI ������Ʈ

        text = this.gameObject.GetComponent<Text>();

    }



    // Update is called once per frame

    void Update()

    {

        //if (DelayCount.DelayCount == 0)    //������ ���� 0�̸�

        {

            //�ǽð� Time.deltaTime �ʱ�ȭ.

            Timer = Timer + Time.deltaTime;

            //�Ǽ��� ���� ù��° �ڸ����� �����Ͽ� UI Text �� ����ȭ

            text.text = string.Format("", Timer);



        }



    }

}