using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InitApplicationData : MonoBehaviour
{
    private void Awake()
    {
        CreateSystemDirectories();
    }

    private void CreateSystemDirectories()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/CharacterRecipes"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/CharacterRecipes");
        }
    }
}
