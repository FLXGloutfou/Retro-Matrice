using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindManager : MonoBehaviour
{
    public InputActionReference MoveRef, JumpRef, NextFabRef, PrevFabRef, CreatRef, RestartRef;

    private void OnEnable()
    {
        MoveRef.action.Disable();
        JumpRef.action.Disable();
        NextFabRef.action.Disable();
        PrevFabRef.action.Disable();
        CreatRef.action.Disable();
        RestartRef.action.Disable();
    }

    private void OnDisable()
    {
        MoveRef.action.Enable();
        JumpRef.action.Enable();
        NextFabRef.action.Enable();
        PrevFabRef.action.Enable();
        CreatRef.action.Enable();
        RestartRef.action.Enable();
    }
}
