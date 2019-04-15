using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    protected override void Init()
    {
    }

    public float playerSpeed = 10f;
    public float speedLimit = 5f;
    
    public GameObject platformRedirect;
    public GameObject platformWind;

    public float platformWindPower;

    public bool isWin = false;
    public bool isRestart = false;
    public bool isPlacementMode = false;
    public bool isStarCollected = false;
    public Vector3 mousePosition;
    public Vector3 startPos;
    public int activePlatform = 0;

    public AudioClip sfxPlayerRun;
    public AudioClip sfxPlayerIdle;
    public AudioClip sfxPlayerFall;

    public AudioClip sfxButtonHover;
    public AudioClip sfxButtonClick;

    // Use this for initialization
    void OnLevelWasLoaded () {
        SetDefaultParameter();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GameStateManager();
    }

    void SetDefaultParameter()
    {
        isPlacementMode = true;
        isWin = false;
        isRestart = false;
    }

    void GameStateManager()
    {
        if (isWin == true && SceneManager.GetActiveScene().name == "MainMenu")
        {
            SetDefaultParameter();
        }
        if (isRestart == true)
        {
            SetDefaultParameter();
        }
        // for auto load next scene if current level is success.
        // only works if scene name use number 1,2,3...
        if (isWin == true)
        {
            if (int.Parse(SceneManager.GetActiveScene().name) + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                int levelNum = int.Parse(SceneManager.GetActiveScene().name) + 1;
                SceneManager.LoadScene(levelNum.ToString());
            }
            SetDefaultParameter();
        }
    }
}
