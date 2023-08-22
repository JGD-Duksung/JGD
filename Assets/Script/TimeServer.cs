using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class TimeServer : MonoBehaviour
{
    public string url = "";
    public Text timeText;
    //private Queue<string> queue = new Queue<string>();
    // Start is called before the first frame update
    void Start()
    {
        /*
        TimeSpan timestamp = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        Debug.Log(timestamp.TotalSeconds);
        Debug.Log("서버시간 알려주는중");

        int past = PlayerPrefs.GetInt("sec", (int)timestamp.TotalSeconds);
        PlayerPrefs.SetInt("sec", (int)timestamp.TotalSeconds);
        Debug.Log(((int)timestamp.TotalSeconds - past));
        */

        StartCoroutine(WebChk());
    }
    void Update()
    {
        /*
        if(queue.Count > 0)
        {
            timeText.text = queue.Dequeue();
        }
        */
    }
    

    IEnumerator WebChk()
    {
        /*
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log("오류:"+request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");

                //Debug.Log("시간:"+date);
                DateTime dateTime = DateTime.Parse(date).ToLocalTime();
                TimeSpan timestamp = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

                int stopwatch = (int)timestamp.TotalSeconds - PlayerPrefs.GetInt("net", (int)timestamp.TotalSeconds);

                Debug.Log("시간:" + dateTime.ToString());
                //Debug.Log(stopwatch+"sec");
                PlayerPrefs.SetInt("net", (int)timestamp.TotalSeconds);
                queue.Enqueue(dateTime.ToString());

                timeText.text = dateTime.ToString();
               
            }
        }*/

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log("오류:" + request.error);
        }
        else
        {
            string date = request.GetResponseHeader("date");
            DateTime dateTime = DateTime.Parse(date).ToLocalTime();
            TimeSpan timestamp = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

            int stopwatch = (int)timestamp.TotalSeconds - PlayerPrefs.GetInt("net", (int)timestamp.TotalSeconds);

            Debug.Log("시간:" + dateTime.ToString());
            // Debug.Log(stopwatch+"sec");
            PlayerPrefs.SetInt("net", (int)timestamp.TotalSeconds);

            // Update UI text directly
            timeText.text = dateTime.ToString();  // Update the UI text with the new time
            Debug.Log("시간 정보 가져옴: " + dateTime.ToString());

          

        }

    }
}
