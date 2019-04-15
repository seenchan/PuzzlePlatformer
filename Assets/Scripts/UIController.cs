using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public string placementModeText;
    public string playModeText;

    private Text startButtonText;

    public string activatePlatformTitle;
    private Text ActivePlatformText;
    private AudioSource audioHUD;

    // Start is called before the first frame update
    void Start()
    {
        FindTextObject();
        startButtonText.text = placementModeText;
        audioHUD = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        SetTextActivePlatform(GameManager.Instance.activePlatform.ToString());
        CheckGameStatus();
    }

    void SetTextActivePlatform(string value)
    {
        ActivePlatformText.text = activatePlatformTitle + value;
    }

    public void StartButtonAction()
    {
        if (GameManager.Instance.isPlacementMode == true)
        {
            GameManager.Instance.isPlacementMode = false;
            startButtonText.text = playModeText;
        }
        else if (GameManager.Instance.isPlacementMode == false)
        {
            GameManager.Instance.isRestart = true;
        }
        PlaySound();
    }

    void CheckGameStatus()
    {
        if (GameManager.Instance.isRestart == true)
        {
            startButtonText.text = placementModeText;
        }
    }

    void FindTextObject()
    {
        startButtonText = GameObject.Find("StartButtonText").GetComponent<Text>();
        ActivePlatformText = GameObject.Find("ActivePlatformText").GetComponent<Text>();
    }

    void PlaySound()
    {
        audioHUD.clip = GameManager.Instance.sfxButtonClick;
        audioHUD.Play();
    }
}
