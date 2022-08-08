using System.Collections;
using System.Collections.Generic;
using System.IO;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarScene : MonoBehaviour
{
    GameObject umaGO;
    // nextButtonGO saves UMA preset file to local directory...
    GameObject nextButtonGO;

    private void Start()
    {
        umaGO = GameObject.Find("UMADynamicCharacterAvatar");
        nextButtonGO = GameObject.Find("NextButton");
        nextButtonGO.GetComponent<Button>().onClick.AddListener(() => { SaveAvatar(); });
    }

    private void SaveAvatar()
    {
        string avatarString = umaGO.GetComponent<DynamicCharacterAvatar>().GetAvatarDefinitionString(true);
        FileSystemCalls.SaveStringToFile(Application.persistentDataPath + "/CharacterRecipes/PlayerAvatar.txt", avatarString);
        SceneManager.LoadScene("UserInfoScene");
    }
}
