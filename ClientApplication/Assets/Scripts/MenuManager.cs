using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject startMenu;
    public InputField usernameField;
    private Button joinServerButton;
    private GameObject canvas;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }
        #endregion
    }

    private void Start()
    {
        this.ConnectToServer();
    }

    public void ConnectToServer()
    {
        StartCoroutine(Connect());
    }

    IEnumerator Connect()
    {
        yield return new WaitForSeconds(1.0f);
        Client.instance.ConnectToServer();
    }
}
