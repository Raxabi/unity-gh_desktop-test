using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraView : MonoBehaviour {
    public float sensitivity = -2f;

    public Transform playerMovement;

    [SerializeField] private float xAxis, yAxis;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        playerMovement.LookAt(new Vector3(0f, 0f, 0f));
        Debug.Log("La cámara puede empezar a girar");
    }

    void Update() {
        xAxis = Input.GetAxis("Mouse X") * sensitivity;
        yAxis = Input.GetAxis("Mouse Y") * Math.Abs(sensitivity);

        yAxis = Mathf.Clamp(yAxis, -90f, 90f);

        var newFacing = new Vector3(yAxis, xAxis, 0f);
        transform.eulerAngles -= new Vector3(newFacing.x, 0f, 0f);
        playerMovement.eulerAngles -= new Vector3(0f, newFacing.y, 0f);
    }
}
