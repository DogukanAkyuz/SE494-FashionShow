using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScene : MonoBehaviour
{
    private GameObject startButtonGO;

    private void Awake()
    {
        startButtonGO = GameObject.Find("StartButton");
    }

    private void Start()
    {
        startButtonGO.GetComponent<Button>().onClick.AddListener(() => { NextScene(); });
    }

    private void NextScene()
    {
        SceneManager.LoadScene("AvatarScene");
    }

}
