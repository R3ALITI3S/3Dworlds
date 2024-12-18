using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI; // see this
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Animations;
using UnityEngine.SceneManagement; // new

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject statsMenu;
    public PlayerMover player;
    public CameraController CC;
    public Transform MainCam;
    public GameObject Tiger;
    public GameObject aim;
    public GameObject gameOver;
    private void Awake() // starts on awake
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
        Pausee();
        MainCam = Camera.main.transform;
        aim.SetActive(false);
        statsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Play() // plays everything
    {
        startMenu.SetActive(false);
        MainCam.SetParent(Tiger.transform, false); // puts the camera as child in tiger
        MainCam.localPosition = new Vector3(2f, 2f, -3.9f);
        MainCam.localRotation = new Quaternion(0f, 0f, 0f, 1f);
        // Time.timeScale = 1f; // the game is now working
        CC.enabled = true;
        player.enabled = true; // it is now possible to use the player
        statsMenu.SetActive(true);
        aim.SetActive(true);
    }

    public void Pausee() // pauses everything
    {
        // Time.timeScale = 0f; // the game is now 'paused'
        CC.enabled = !CC.enabled;
        player.enabled = !player.enabled; // the player is now not enabled, not updated
        aim.SetActive(!aim.activeSelf); // activates and deactivates crosshair
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        // Time.timeScale = 0f; // the game is now 'paused'
        CC.enabled = !CC.enabled;
        player.enabled = !player.enabled; // the player is now not enabled, not updated
        aim.SetActive(!aim.activeSelf); // activates and deactivates crosshair
        gameOver.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    // Method to load the "Sample Scene"
    public void PlayAgain()
    {
        // Load the SampleScene (replace with the exact name of your scene)
        SceneManager.LoadScene("SampleScene");
    }

}