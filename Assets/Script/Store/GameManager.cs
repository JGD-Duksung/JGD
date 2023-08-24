using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public Item(string _Type, string _Name, string _Explain, string _Number, bool _isUsing, bool _myItem)
    {
        Type = _Type; Name = _Name; Explain = _Explain; Number = _Number; isUsing = _isUsing;  myItem = _myItem;
    }

    public string Type, Name, Explain, Number;
    public bool isUsing, myItem;
}



public class GameManager : MonoBehaviour
{


    public TextAsset ItemDatabase;
    public List<Item> AllItemList, MyItemList, CurItemList;
    public string curType = "Store";
    public GameObject[] Slot, UsingImage, BuyButton;
    public Image[] TabImage, ItemImage;
    public Sprite TabIdleSprite, TabSelectSprite;
    public Sprite[] ItemSprite; // ������ ����



    void Start()
    {
        //��ü ������ ����Ʈ �ҷ�����
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        
        for (int i = 0; i <  line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4] == "TRUE", row[5] == "TRUE"));
        }
        Load();
    }


    // ���濡 ������ ������ �� ������ ������ ����
    public void SlotClick(int slotNum)
    {
        Item CurItem = CurItemList[slotNum];
        Item UsingItem = CurItemList.Find(x => x.isUsing == true);

        if (curType == "Bag")
        {
            if (UsingItem != null) UsingItem.isUsing = false;
            CurItem.isUsing = true;
        }
        Save();
    }


    // ���� ������ �� ����
    public void BuyButtonClick(int slotNum)
    {
        Item CurItem = CurItemList[slotNum];
        //Item MyItem = CurItemList.Find(x => x.myItem == false);

        if (curType == "Store")
        {
            CurItem.myItem = true;
        }
        Save();
    }



    public void TabClick(string tabName)
    {
        // ����, ���� Ŭ�� �̺�Ʈ
        curType = tabName;
        if (curType == "Store")
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == false); // ������ �� myItem�� �ƴѰ͸� ã�Ƽ� Cur�� �ֱ�
        } else
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == true); // ������ �� myItem�ΰ͸� ã�Ƽ� Cur�� �ֱ�
        }


        for (int i = 0; i < Slot.Length; i++)
        {
            // ����, ���濡 �ִ� ������ ���̱�
            bool isExist = i < CurItemList.Count;
            Slot[i].SetActive(isExist);
            Slot[i].transform.GetChild(0).GetComponent<Text>().text = isExist ? CurItemList[i].Name : "";
            Slot[i].transform.GetChild(3).GetComponent<Text>().text = isExist ? CurItemList[i].Explain : "";

            // ������ �̹����� ���뿩��, ���Ź�ư ���̱�
            if (isExist)
            {
                ItemImage[i].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == CurItemList[i].Name)];
                UsingImage[i].SetActive(CurItemList[i].isUsing);
                BuyButton[i].SetActive(!CurItemList[i].myItem);
            }
        }

        int tabNum = 0;
        switch (tabName) // ����, ���� ��ư Ȱ��ȭ ����
        {
            case "Store": tabNum = 0; break;
            case "Bag": tabNum = 1; break;
        }
        for (int i = 0; i < TabImage.Length; i++)
            TabImage[i].sprite = i == tabNum ? TabSelectSprite : TabIdleSprite;
    }



    void Save()
    {
        string jdata = JsonConvert.SerializeObject(MyItemList);
        File.WriteAllText(Application.dataPath + "/StoreResources/MyItemText.txt", jdata);

        TabClick(curType);
    }



    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/StoreResources/MyItemText.txt");
        MyItemList = JsonConvert.DeserializeObject<List<Item>>(jdata);

        TabClick(curType);
    }
}
