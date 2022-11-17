using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class scr_Camera : MonoBehaviour
{
    //[SerializeField]
    public float turnSpeed;
    //[SerializeField]
    public Transform this_obj;

    public GameObject photo;

    bool picTaken = false;

    void Start()
    {
        //photo = GameObject.FindGameObjectWithTag("Photo");
        //photo.GetComponent<PictureBehavior>().Cheese();
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
                    photo.gameObject.SetActive(true);
                    picTaken = true;
                }
            }
        }
    }
}
