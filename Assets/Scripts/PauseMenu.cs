using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    private GameObject menu;
    private LastPlayerSighting gameController;
    private Slider soundSlider, musicSlider;
    private AudioSource music;
    private bool musicPlaying;
    private FadeManager screenFader;
    private List<AudioSource> audioSources;

    void Awake()
    {
        menu = GameObject.FindGameObjectWithTag(Tags.pauseMenu);
        gameController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
        music = GetComponent<AudioSource>();
        musicPlaying = true;
        screenFader = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<FadeManager>();

        musicSlider = GameObject.FindGameObjectWithTag(Tags.musicSlider).GetComponent<Slider>();

        musicSlider.value = gameController.musicVolume;
        menu.SetActive(false);
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
        Time.timeScale = 1;
        screenFader.FadeOut(SceneManager.GetActiveScene().buildIndex);
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

    public void OnMusicVolumeChanged()
    {
        gameController.musicVolume = musicSlider.value;
        gameController.panicVolume = musicSlider.value;
    }

    public void OnSoundVolumeChanged()
    {
        
    } 

    public void Quit()
    {
        menu.SetActive(false);
        screenFader.FadeOut(0);
    }
}
