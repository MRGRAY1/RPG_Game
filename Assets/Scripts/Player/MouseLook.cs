using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private float mouseSensitivity = 100f;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float xRotation = 0f;

    [SerializeField]
    private MainInput controls;
    private Vector2 mouseDelta;

    #endregion

    private void Awake()
    {
        this.controls = new MainInput();

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    private void OnEnable()
    {
        this.controls.Enable();
    }
    private void OnDisable()
    {
        this.controls.Disable();
    }


    //Update is called once per frame
    private void Update()
    {
        this.mouseDelta = this.controls.PlayerMovement.Look.ReadValue<Vector2>();

        float mouseX = this.mouseDelta.x * this.mouseSensitivity * Time.deltaTime;
        float mouseY = this.mouseDelta.y * this.mouseSensitivity * Time.deltaTime;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);

        this.cameraTransform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);

        this.transform.Rotate(Vector3.up * mouseX);
    }
}
