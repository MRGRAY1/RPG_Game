using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackgroundTool : MonoBehaviour
{
    private MainInput controls;
    private void Awake()
    {
        this.controls = new MainInput();
    }
    private void OnEnable()
    {
        this.controls.Enable();
        this.controls.Background.Debug.performed += DebugState;
    }


    private void OnDisable()
    {
        this.controls.Background.Debug.performed -= DebugState;
        this.controls?.Disable();
    }
    private void DebugState(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        if (GameManager.Debugging)
        {
            Logger.EventLog("Debugging Disabled");
            GameManager.DisableDebug();
        }
        else
        {
            Logger.EventLog("Debugging Enabled");
            GameManager.EnableDebug();
        }
    }
}
