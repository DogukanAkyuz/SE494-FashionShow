using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class InstantiateModel : MonoBehaviour
{
    GameObject currentModel;
    private Object[] modelList;
    int currentIndex;
    int index;

    private void Awake() {
        modelList = Resources.LoadAll("Models", typeof(GameObject));
        index = modelList.Length;
        currentIndex = 0;
    }

    void Start()
    {
        currentModel = GameObject.Instantiate(modelList[currentIndex] as GameObject);
        currentModel.gameObject.tag = "Model";
        Debug.Log(GameObject.Find("Path").GetComponent<PathCreator>());
        currentModel.AddComponent<Follower>();
        currentModel.GetComponent<Follower>().pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();
        currentModel.AddComponent<SphereCollider>();
        currentModel.AddComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Model")
        {
            Destroy(currentModel);
            if(currentIndex == index - 1)
            {
                currentIndex = 0;
            }
            else
                currentIndex++;

            currentModel = GameObject.Instantiate(modelList[currentIndex] as GameObject);
            currentModel.gameObject.tag = "Model";
            currentModel.AddComponent<Follower>();
            currentModel.GetComponent<Follower>().pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();
            currentModel.AddComponent<SphereCollider>();
            currentModel.AddComponent<Rigidbody>();
        }
    }
}
