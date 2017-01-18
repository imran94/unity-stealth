using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public Button button_lvl1;
    public Button button_lvl2;
    Animator anim;

    void Start()
    {
        Time.timeScale = 0.0f;
        anim = GetComponent<Animator>();
        Button btn1 = button_lvl1.GetComponent<Button>();
        Button btn2 = button_lvl2.GetComponent<Button>();
        btn1.onClick.AddListener(StartLvl1);
        btn2.onClick.AddListener(StartLvl2);
    }

    void StartLvl1()
    {
        anim.SetTrigger("MenuFade");
        Time.timeScale = 1.0f;
    }

    void StartLvl2()
    {
        SceneManager.LoadScene("Scene 2");
    }
}
