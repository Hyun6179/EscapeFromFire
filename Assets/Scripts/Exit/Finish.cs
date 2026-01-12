using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour 
{
    [SerializeField] private GameObject LC;
    [SerializeField] private GameObject R;

    [SerializeField]
    private Button Success;
    [SerializeField]
    private Button Failure;

    [SerializeField]
    private TMP_Text ResultT;

    [SerializeField]
    private Button Reset;
    [SerializeField]
    private Button End;

    // Start is called before the first frame update
    void Start()
    {
        LC.gameObject.SetActive(true);
        R.gameObject.SetActive(false);
        ButtonOff(Reset, End);
        Success.onClick.AddListener(Win);
        Failure.onClick.AddListener(Lose);
        Reset.onClick.AddListener(ReGame);
        End.onClick.AddListener(EndGame);
    }

    public void Lose()
    {
        LC.gameObject.SetActive(false);
        R.gameObject.SetActive(true);
        ResultT.text = "Bad End... \n사망하셨습니다.";
        ButtonOff(Failure, Success);
        ButtonOn(Reset, End);
    }

    public void Win()
    {
        LC.gameObject.SetActive(false);
        R.gameObject.SetActive(true);
        ResultT.text = "Happy End! \n축하합니다!";
        ButtonOff(Failure, Success);
        ButtonOn(Reset, End);
    }

    public void ReGame()
    {
        SceneManager.LoadScene("HouseScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void ButtonOn(Button bt1, Button bt2)
    {
        bt1.gameObject.SetActive(true);
        bt2.gameObject.SetActive(true);
    }

    public void ButtonOff(Button bt1, Button bt2)
    {
        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
    }
}
