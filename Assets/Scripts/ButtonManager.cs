using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //Loads scene based on the index of each scene
    }
}
