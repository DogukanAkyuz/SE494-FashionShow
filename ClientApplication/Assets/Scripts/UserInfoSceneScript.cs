using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UserInfoSceneScript : MonoBehaviour
{
    [SerializeField] private Button joinButton;
    [SerializeField] private TextMeshProUGUI _ipAddress;
    [SerializeField] private TextMeshProUGUI _userName;

    private void Start()
    {
        joinButton.onClick.AddListener(() => { 
            SaveSettings();
            SceneManager.LoadScene("InstructionsScene");
        });
    }

    private void SaveSettings()
    {
        UserInfoScene.instance.ipAddress = _ipAddress.text;
        UserInfoScene.instance.userName = _userName.text;
    }
}
