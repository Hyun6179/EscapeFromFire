using OVR.OpenVR;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 100;
    public Slider HpBarSlider;

    public CharacterController noMove;
    public GameObject DResult;
    public TMP_Text text;
    public Button Re;
    public Button End;

    private void Start()
    {
        SetHP();
        DResult.SetActive(false);
        noMove.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (DResult.activeInHierarchy == true)
        {
            noMove.Move(Vector3.zero);

            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
                SceneManager.LoadScene("LobbyScene");

            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
                SceneManager.LoadScene("HouseScene");
        }
    }

    public void SetHP()
    {
        maxHealth = 100;
        curHealth = maxHealth;
    }


    public void CheckHP()
    {
        if (HpBarSlider != null)
        {
            HpBarSlider.value = curHealth / maxHealth;
        }
    }

    public void getDamage(float damage)
    {
        curHealth -= damage;
        CheckHP();
        if (curHealth <= 0) 
        {
            curHealth = 0;/* 체력이 0 이므로 게임종료, 즉 사망*/
            DResult.SetActive(true);
            Dead();
        }
    }

    private void Dead()
    {
        text.text = "가스를 너무 마셔서\n사망하셨습니다.";
    }
}
