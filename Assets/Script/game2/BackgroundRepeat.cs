using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    //��ũ���� �ӵ� ����
    public float scrollSpeed = 1.2f;
    //������ ���͸��� �����͸� �޾ƿ� ��ü ����
    private Material thisMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //��ü�� ������ �� ���� 1ȸ ȣ��Ǵ� �Լ�
        //���� ��ü�� Component���� ����, Renderer������Ʈ�� ���͸������� �޾ƿ�

        thisMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //���Ӱ� �������� offset ��ü ����
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //y�κп� ���� y���� �ӵ��� ������ ������ �ؼ� ������
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));
        //���������� offset�� ����
        thisMaterial.mainTextureOffset = newoffset;
    }
}
