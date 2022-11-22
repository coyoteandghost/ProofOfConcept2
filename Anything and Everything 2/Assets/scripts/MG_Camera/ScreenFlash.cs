using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    Image _image = null;
    Coroutine _currentFlashRoutine = null;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxAplha, Color newColor)
    {
        _image.color = newColor;

        maxAplha = Mathf.Clamp(maxAplha, 0, 1);

        if (_currentFlashRoutine != null)
            StopCoroutine(_currentFlashRoutine);
        _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAplha));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAplha)
    {
        float flashInDuration = secondsForOneFlash / 2;
        for(float t = 0; t <= flashInDuration; t+= Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(0,maxAplha, t / flashInDuration);
            _image.color = colorThisFrame;
            yield return null;
        }

        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(maxAplha, 0, t / flashOutDuration);
            _image.color = colorThisFrame;
            yield return null;
        }

        //failsafe: set alpha to 0
        _image.color = new Color32(0, 0, 0, 0);
    }
}
