using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myid = _packet.ReadInt();

        Debug.Log($"Message from server. {_msg}");
        Client.instance.myId = _myid;
        ClientSend.WelcomeReceived();
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        string _avatarData = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        SaveAvatarData(_id, _avatarData);

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void SaveAvatarData(int _id, string _avatarData)
    {
        string filePath = Application.persistentDataPath + "/CharacterRecipes/" + _id.ToString() + ".txt";
        FileSystemCalls.SaveStringToFile(filePath, _avatarData);
    }
}
