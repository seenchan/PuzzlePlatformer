using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody playerRB;
    public int moveDir = 1;
    private bool isGrounded = false;

    public Vector3 startPos;

    private Animator playerAnim;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        GameManager.Instance.startPos = this.transform.position;
        startPos = this.transform.position;
        playerAnim = this.GetComponent<Animator>();
        playerAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.Instance.isRestart == true || GameManager.Instance.isPlacementMode == true)
        {
            this.transform.position = GameManager.Instance.startPos;
            //this.transform.position = startPos;
            playerRB.isKinematic = true;
            playerRB.isKinematic = false;
            SetPlayerAnim("Idle");
        }
        if (GameManager.Instance.isPlacementMode == false && isGrounded == true)
        {
            MovePlayer(moveDir);
            SetPlayerAnim("Run");
        }
    }

    void MovePlayer(int dir)
    {
        if (playerRB.velocity.x <= GameManager.Instance.speedLimit)
        {
            playerRB.AddForce(Vector3.right * GameManager.Instance.playerSpeed * dir);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.name == GameManager.Instance.platformRedirect.name)
        {
            moveDir = moveDir * -1;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Lethal")
        {
            GameManager.Instance.isRestart = true;
        }
        if (hit.tag == "Finish")
        {
            GameManager.Instance.isWin = true;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.tag != "Player")
        {
            isGrounded = true;
            SetPlayerAnim("Run");
        }
    }

    void OnTriggerExit (Collider hit)
    {
        if (hit.tag != "Player")
        {
            isGrounded = false;
            SetPlayerAnim("Fall");
        }
    }

    void SetPlayerAnim(string state)
    {
        if (state == "Run")
        {
            playerAnim.SetBool("IsPlayerRun", true);
            playerAnim.SetBool("IsPlayerIdle", false);
            playerAnim.SetBool("IsPlayerFall", false);
        }
        else if (state == "Idle")
        {
            playerAnim.SetBool("IsPlayerRun", false);
            playerAnim.SetBool("IsPlayerIdle", true);
            playerAnim.SetBool("IsPlayerFall", false);
        }
        else if (state == "Fall")
        {
            playerAnim.SetBool("IsPlayerRun", false);
            playerAnim.SetBool("IsPlayerIdle", false);
            playerAnim.SetBool("IsPlayerFall", true);
        }
        SetPlayerAudio(state);
    }

    void SetPlayerAudio(string state)
    {
        if (state == "Run" && playerAudio.clip != GameManager.Instance.sfxPlayerRun)
        {
            playerAudio.Stop();
            playerAudio.clip = GameManager.Instance.sfxPlayerRun;
            playerAudio.loop = true;
            playerAudio.Play();
        }
        else if (state == "Idle" && playerAudio.clip != GameManager.Instance.sfxPlayerIdle)
        {
            playerAudio.Stop();
            playerAudio.clip = GameManager.Instance.sfxPlayerIdle;
            playerAudio.loop = false;
            playerAudio.Play();
        }
        else if (state == "Fall" && playerAudio.clip != GameManager.Instance.sfxPlayerFall)
        {
            playerAudio.Stop();
            playerAudio.clip = GameManager.Instance.sfxPlayerFall;
            playerAudio.loop = false;
            playerAudio.Play();
        }
    }
}
