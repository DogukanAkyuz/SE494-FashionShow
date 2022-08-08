using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRInit2 : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(StartVR());
    }

    IEnumerator StartVR()
    {
        yield return new WaitForSeconds(3.5f);
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        XRGeneralSettings.Instance.Manager.StartSubsystems();
    }
}
