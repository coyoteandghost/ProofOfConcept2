using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class titleScreen : MonoBehaviour
{
    private bool keyPressed = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            keyPressed = true;
        }

        Debug.Log(keyPressed);
        if (keyPressed ==true)
        {
            Switch();
        }
    }

    public void Switch()
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneToLoad > SceneManager.sceneCountInBuildSettings - 1)
        {
            sceneToLoad = 0;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
