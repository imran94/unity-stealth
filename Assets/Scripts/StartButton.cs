using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    public Button button_start;
    Animator anim;

    void Start()
    {
        Time.timeScale = 0.0f;
        anim = GetComponent<Animator>();
        Button btn = button_start.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        anim.SetTrigger("MenuFade");
        Time.timeScale = 1.0f;
    }
}
