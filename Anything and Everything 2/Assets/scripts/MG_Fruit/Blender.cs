using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blender : MonoBehaviour
{
    public AudioSource blend_noise;
    public float fruitLeft;
    [SerializeField]
    int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
       if(fruitLeft <= 0)
        {
            StartCoroutine(NextScene());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fruit")
        {
            blend_noise.Play();
            fruitLeft -= 1;
        }
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneToLoad);
    }
}
