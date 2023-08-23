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
    public GameObject[] Slot, UsingImage;
    public Image[] TabImage, ItemImage;
    public Sprite TabIdleSprite, TabSelectSprite;
    public Sprite[] ItemSprite; // 아이템 에셋



    void Start()
    {
        //전체 아이템 리스트 불러오기
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        
        for (int i = 0; i <  line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4] == "TRUE", row[5] == "TRUE"));
        }
        Load();
    }


    // 가방에 소지한 아이템 중 장착할 아이템 선택
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



    public void TabClick(string tabName)
    {
        // 상점, 가방 클릭 이벤트
        curType = tabName;
        if (curType == "Store")
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == false);
        } else
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == true);
        }


        for (int i = 0; i < Slot.Length; i++)
        {
            // 상점, 가방에 있는 아이템 보이기
            bool isExist = i < CurItemList.Count;
            Slot[i].SetActive(isExist);
            Slot[i].GetComponentInChildren<Text>().text = isExist ? CurItemList[i].Name : "";

            // 아이템 이미지와 착용여부 보이기
            if (isExist)
            {
                ItemImage[i].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == CurItemList[i].Name)];
                UsingImage[i].SetActive(CurItemList[i].isUsing);
            }
        }

        int tabNum = 0;
        switch (tabName) // 상점, 가방 버튼 활성화 여부
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
