using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandling : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Camera _mainCamera;
    public colorChangingScript colorChangingScript;
    public DataLoggerScript dataLoggerScript;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    void Update() {
        dataLoggerScript.time += Time.deltaTime;
    }
    // Update is called once per frame
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) {return;}
        else {
            dataLoggerScript.FinalTime = dataLoggerScript.time;
            dataLoggerScript.time = 0;
            colorChangingScript.changeColor(rayHit.collider.gameObject);
        }


        Debug.Log(rayHit.collider.gameObject.name);      
    }
}
