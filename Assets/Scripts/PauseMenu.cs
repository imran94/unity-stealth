using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private GameObject menu;
    private AudioSource music;
    private bool musicPlaying;

	void Awake()
    {
        menu = GameObject.FindGameObjectWithTag(Tags.pauseMenu);
        music = GetComponent<AudioSource>();
        menu.SetActive(false);
        musicPlaying = true;
	}
	
	void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleMusic()
    {
        if (musicPlaying)
        {
            music.mute = true;
            //music.Pause();
            musicPlaying = false;
        }
        else
        {
            music.mute = false;
            //music.UnPause();

            musicPlaying = true;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
