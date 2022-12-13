using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

public class Platform_Controller : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform holder;
    [SerializeField]
    bool flippedZ = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(flippedZ == false)
        {
            Vector3 rotation = new Vector3(0, 0, -input.x);
            holder.Rotate(rotation * speed * Time.deltaTime);
        }
        else
        {
            Vector3 rotation = new Vector3(0, 0, input.x);
            holder.Rotate(rotation * speed * Time.deltaTime);
        }
    }
}
