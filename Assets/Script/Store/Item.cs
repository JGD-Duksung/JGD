using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public static GameObject selectitem;
    public static bool buyitem = false;
    public List<GameObject> Items = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectItem()
    {
        selectitem = EventSystem.current.currentSelectedGameObject;
    }
}
