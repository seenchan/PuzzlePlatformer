using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonController : MonoBehaviour
{
    private AudioSource audioHUD;

    void Start()
    {
        audioHUD = this.GetComponent<AudioSource>();
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        PlaySound();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void PlaySound()
    {
        audioHUD.Play();
    }
}
