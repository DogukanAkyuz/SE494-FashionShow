using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileSystemCalls : MonoBehaviour
{
    public static void SaveStringToFile(string _filePath, string _avatarData)
    {
        File.WriteAllText(_filePath, _avatarData);
    }

    public static string LoadStringFromFile(string _filePath)
    {
        string fileData = File.ReadAllText(_filePath);
        return fileData;
    }

    public static string LoadPlayerAvatar()
    {
        string filePath = Application.persistentDataPath + "/CharacterRecipes/PlayerAvatar.txt"; 
        string playerAvatar = File.ReadAllText(filePath);
        return playerAvatar;
    }
}
