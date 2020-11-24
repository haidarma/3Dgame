using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerView : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //We want to lock our cursor in the middle
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerRotation();
    }

    //Rotate the player body and camera
    void playerRotation()
    {
        //Get the current value of where the mouse is and place it in variable
        //Multiply it by mouseSensitivity for movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotate -= mouseY;

        //to avoid over rotation
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
