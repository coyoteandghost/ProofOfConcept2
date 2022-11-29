using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class PictureBehavior : MonoBehaviour
{
    WebCamTexture webcam;
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (var i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        webcam = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcam;
        StartCoroutine(Cheese());
    }

    private void OnDestroy()
    {
        webcam.Stop();
    }
    IEnumerator Cheese()
    {
        webcam.Play();
        yield return new WaitForSeconds(1);
        webcam.Pause();
    }
}
