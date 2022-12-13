using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blender : MonoBehaviour
{
    public AudioSource blend_noise;
    public float fruitLeft;
    public ParticleSystem fruitSplat;
    [SerializeField]
    //int sceneToLoad;
    private void Start()
    {
        
    }
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
            fruitSplat.Emit(10);
            fruitLeft -= 1;
        }
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneToLoad > SceneManager.sceneCountInBuildSettings - 1)
        {
            sceneToLoad = 0;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
