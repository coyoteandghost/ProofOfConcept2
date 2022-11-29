using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityEngine.SceneManagement;

public class scr_Camera : MonoBehaviour
{
    //[SerializeField]
    public float turnSpeed;
    //[SerializeField]
    public Transform this_obj;

    public GameObject photo;

    public AudioSource shutterSound;

    [SerializeField] ScreenFlash screenFlash = null;

    bool picTaken = false;

    public int sceneToLoad = 0;

    void Start()
    {
        //photo = GameObject.FindGameObjectWithTag("Photo");
        //photo.GetComponent<PictureBehavior>().Cheese();
        shutterSound = GetComponent<AudioSource>();

        //screenFlash.StartFlash(1f, 0.5f, Color.white);
    }

    void LateUpdate()
    {
        if (picTaken == false)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 rotation = new Vector3(0, 0, -input.x);
            this_obj.Rotate(rotation * turnSpeed * Time.deltaTime);
            float rot = this_obj.transform.rotation.eulerAngles.y;
            if (rot >= 0 && rot <= 2)
            {
                if(input.y < 0)
                {
                    shutterSound.Play();
                    screenFlash.StartFlash(2f,0.75f,Color.white);
                    photo.gameObject.SetActive(true);
                    picTaken = true;
                }
            }
        }
        if(picTaken == true)
            StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneToLoad);
    }
}
