using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Debug = UnityEngine.Debug;

public class PlayerPos
{
    private Vector3 _position;
    private bool _isAvailable;
     
    public PlayerPos(Vector3 position, bool isAvailable)
    {
        _position = position;
        _isAvailable = isAvailable;
    }

    public Vector3 GetPos()
    {
        return _position;
    }

    public bool GetAvailability()
    {
        return _isAvailable;
    }

    public void SetAvailability(bool set)
    {
        _isAvailable = set;
    }
}

// The following script must be placed in all scenes attached to a GameObject named as "InstantiatePlayer" in order to work...
public class InstantiatePlayer : MonoBehaviour
{
    #region Singleton
    private static InstantiatePlayer _instance;
    public static InstantiatePlayer Instance
    {
        get
        {
            if (InstantiatePlayer._instance == null)
            {
                InstantiatePlayer._instance = GameObject.Find("InstantiatePlayer").GetComponent<InstantiatePlayer>();
                InstantiatePlayer._instance.Init();
                DontDestroyOnLoad(InstantiatePlayer._instance.gameObject);
            }
            return InstantiatePlayer._instance;
        }
    }
    #endregion

    private PlayerPos[] _playerPosList;
    private int _playerCt;

    public void Init(int playerCt = 10)
    {
        _playerCt = playerCt;
        _playerPosList = new PlayerPos[]{
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, -6.394266f), true),
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, -3.894266f), true),
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, -1.394266f), true),
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, 1.105734f), true),
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, 3.605734f), true),
             new PlayerPos(new Vector3(-15.71047f, 2.109212f, 6.105734f), true),
             new PlayerPos(new Vector3(-18.96047f, 2.109212f, 2.355734f), true),
             new PlayerPos(new Vector3(-18.96047f, 2.109212f, -0.1442661f), true),
             new PlayerPos(new Vector3(-18.96047f, 2.109212f, -2.644266f), true),
         };
    }

    public Vector3 GetPosition()
    {
        for (int i = 0; i < _playerCt; i++)
        {
            if (_playerPosList[i].GetAvailability())
            {
                _playerPosList[i].SetAvailability(false);
                return _playerPosList[i].GetPos();
            }
        }
        Debug.LogError("There are no spaces left!");
        throw new InvalidOperationException();
    }

    private void Awake()
    {
        #region Singleton
        if (InstantiatePlayer._instance == null)
        {
            InstantiatePlayer._instance = GameObject.Find("InstantiatePlayer").GetComponent<InstantiatePlayer>();
            InstantiatePlayer._instance.Init();
            DontDestroyOnLoad(InstantiatePlayer._instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
}
