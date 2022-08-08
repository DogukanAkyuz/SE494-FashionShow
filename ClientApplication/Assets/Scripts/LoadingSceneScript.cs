using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cttext;
    private float speed = 2.0f;
    private float countdown = 10.0f;

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            SceneManager.LoadScene("FashionShowScene");
        }
        int convert = (int)countdown + 1;
        cttext.text = convert.ToString();
    }
}
