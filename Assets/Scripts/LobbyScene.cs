using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour 
{ 
    public void End()
    {
        Application.Quit();
    }

    public void GetStart()
    {
        SceneManager.LoadScene("HouseScene");
    }

}
