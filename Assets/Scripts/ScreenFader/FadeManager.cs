using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour {

    private bool inTransition, isShowing;
    private float transition, duration;

    private bool sceneStarting = true;
    private int sceneIndex;

    public float fadeSpeed = 1.5f;
    public Image fadeImage;

    void Awake()
    {
        fadeImage = gameObject.GetComponent<Image>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        FadeIn();
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
        if (!inTransition) return;

        transition += isShowing ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
        {
            inTransition = false;

            if (transition > 1)
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
	}

    public void FadeIn()
    {
        Fade(false, 2f);
    }

    public void FadeOut(int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
        Fade(true, 2f);
    }
}
