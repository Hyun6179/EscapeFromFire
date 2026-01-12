using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireManage : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public TMP_Text text;
    public GameObject canvas;
    private void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (fire1.gameObject.activeInHierarchy == false &&  fire2.gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(false);
            Clear();
        }
    }

    void Clear()
    {
        canvas.SetActive(true);
        text.text = "화재 진압 성공!";
    }
}
