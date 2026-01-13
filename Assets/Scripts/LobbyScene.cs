using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    public Button start;
    public Button end;

    void Start()
    {
        start.onClick.AddListener(GetStart);
        end.onClick.AddListener(End);
    }

    private void End()
    {
        Application.Quit();
    }

    private void GetStart()
    {
        SceneManager.LoadScene("HouseScene");
    }

}
