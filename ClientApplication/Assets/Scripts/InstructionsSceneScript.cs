using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

enum VRType
{
    Cardboard,
    Gear
};

public class InstructionsSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject loading;
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private Button cardboard;
    [SerializeField] private Button gear;
    [SerializeField] private Button skip;


    private VRType vrType;

    private void Awake()
    {
        loading.SetActive(false);
        cardboard.onClick.AddListener(() => { 
            vrType = VRType.Cardboard;
            selection.SetActive(false);
            LoadVideo();
        });

        gear.onClick.AddListener(() => { 
            vrType = VRType.Gear;
            selection.SetActive(false);
            LoadVideo();
        });

        skip.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoadingScene");
        });
    }

    private void LoadVideo()
    {
        loading.SetActive(true);
        if (vrType == VRType.Cardboard)
            videoPlayer.clip = Resources.Load<VideoClip>("Videos/Cardboard");
        else
            videoPlayer.clip = Resources.Load<VideoClip>("Videos/Gear");
    }
}
