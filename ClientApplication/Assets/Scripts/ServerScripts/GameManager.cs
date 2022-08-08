using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA.CharacterSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        #endregion
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if(_id % 2 == 0)
        {
            _rotation *= Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

        if(_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            StartCoroutine(LoadPlayerAvatar(_id.ToString(), _player));
            StartCoroutine(DestroyRB(_player, _position));
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
            StartCoroutine(LoadPlayerAvatar(_id.ToString(), _player));
            StartCoroutine(DestroyRB(_player, _position));
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    IEnumerator LoadPlayerAvatar(string _fileName, GameObject _player)
    {
        yield return new WaitForSeconds(1.0f);
        string filePath = Application.persistentDataPath + "/CharacterRecipes/" + _fileName + ".txt";
        string avatarData = FileSystemCalls.LoadStringFromFile(filePath);
        _player.GetComponent<DynamicCharacterAvatar>().LoadAvatarDefinition(avatarData);
        _player.GetComponent<DynamicCharacterAvatar>().BuildCharacter(false);
    }

    IEnumerator DestroyRB(GameObject _player, Vector3 _position)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(_player.GetComponent<Rigidbody>());
        Destroy(_player.GetComponent<CapsuleCollider>());
        yield return null;
        _player.transform.position = _position;
        yield return null;
        _player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Sitting");
    }
}
