using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoScene : MonoBehaviour
{
    public static UserInfoScene instance;
    public string ipAddress;
    public string userName;

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

    
}
