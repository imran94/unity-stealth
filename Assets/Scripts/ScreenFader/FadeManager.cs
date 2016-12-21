using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour {

    public static FadeManager Instance { set; get; }

    public Image fadeImage;

    private bool inTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    public float fadeSpeed = 1.5f;
    private bool sceneStarting = true;

    void Awake()
    {
        Instance = this;
        fadeImage = GetComponentInChildren<Image>();
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        inTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Fade(true, 1.25f);
        }

        if (!inTransition) return;

        transition += isShowing ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
            inTransition = false;
	}

    void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();

        if (fadeImage.color.a <= 0.05f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        fadeImage.enabled = true;
        FadeToBlack();

        if (fadeImage.color.a >= 0.95f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
