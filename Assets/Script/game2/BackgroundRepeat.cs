using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    //스크롤할 속도 지정
    public float scrollSpeed = 1.2f;
    //쿼드의 머터리얼 데이터를 받아올 객체 선언
    private Material thisMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //객체가 생성될 때 최초 1회 호출되는 함수
        //현재 객체의 Component들을 참조, Renderer컴포넌트의 머터리얼정보 받아옴

        thisMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //새롭게 지정해줄 offset 객체 선언
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //y부분에 현재 y값에 속도에 프레임 보정을 해서 더해줌
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));
        //최종적으로 offset값 지정
        thisMaterial.mainTextureOffset = newoffset;
    }
}
