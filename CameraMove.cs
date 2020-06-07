using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float sensitivityMouse = 2f;
    public float Rotx;
    public float Roty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotx = -Input.GetAxis("Mouse Y") * sensitivityMouse;
        Roty = Input.GetAxis("Mouse X") * sensitivityMouse;
   
        
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Roty, 0);
        }


    }
}
