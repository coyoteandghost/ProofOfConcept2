using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//FIND A WAY TO INTERACT WITH THE BUTTONS
//TIMED EVENT ????
//WIN STATE: MAKE THE PET HAPPY (SOME KIND OF BAR THAT GOES ALL THE WAY UP )

public class cameraKern : MonoBehaviour
{
    public Transform endPosition = null;

    bool canInteract = false;
    bool buttonsActive;

    public GameObject food;
    public GameObject sleep;
    public GameObject hygiene;
    public GameObject game;

    private bool allStatsActive = false; //whether or not all the 4 stats are active

    void Update()
    {
        if (!canInteract)
        {
            if (Input.anyKey)
            {
                canInteract = true; //PRESSING ANY KEY MAKES canInteract TRUE
            }
        }

        if (canInteract) // LERPS THE CAMERA TO THE POSITION
        {
            transform.position = Vector3.Lerp(transform.position, endPosition.position, Time.deltaTime*3);
            StartCoroutine(ButtonCoroutine());
        }

        if (food.activeSelf && game.activeSelf && hygiene.activeSelf && sleep.activeSelf)
        {
            allStatsActive = true;
        }
    }

    IEnumerator ButtonCoroutine()
    {
        buttonsActive = false;
        yield return new WaitForSeconds(1);
        buttonsActive = true;
        if (buttonsActive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                food.SetActive(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                game.SetActive(true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                hygiene.SetActive(true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                sleep.SetActive(true);
            }
        }
        if (allStatsActive)
        {
            StartCoroutine(SceneEndCoroutine());
        }
    }
    IEnumerator SceneEndCoroutine() //ENDS THE SCENE IF ALL STATS ARE ACTIVE AND GOES TO NEXT ROOM
    {
        yield return new WaitForSeconds(1);
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; //move to next scene

        if (sceneToLoad > SceneManager.sceneCountInBuildSettings - 1) //if you hit the last scene, go to title screen
            sceneToLoad = 0;

        SceneManager.LoadScene(sceneToLoad); //load the scene #

    }

}
