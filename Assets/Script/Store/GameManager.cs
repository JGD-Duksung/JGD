using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset ItemDatabase;
    // Start is called before the first frame update
    void Start()
    {
        print(ItemDatabase.text);
    }
}
