using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float decayRate = 5f;
    #region Move Camera Variables
    [SerializeField] float dragSensitivity = 0f;
    private Vector3 dragDirection = Vector3.zero;
    #endregion
    #region Zoom Camera Variables
    [SerializeField] float zoomSensitivity = 0f;
    [SerializeField] float zoomMin = 0f;
    [SerializeField] float zoomMax = 0f;
    private float startDistance = 0f;
    private float currentDistance = 0f;
    private float pinchDelta = 0f;
    #endregion

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            dragDirection.x = Input.GetTouch(0).deltaPosition.x / (float)Screen.width;
            dragDirection.z = Input.GetTouch(0).deltaPosition.y / (float)Screen.height;
        }
        else if(Input.touchCount == 2)
        {
            if(Input.GetTouch(1).phase == TouchPhase.Began)
            {
                startDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                currentDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                pinchDelta = currentDistance - startDistance;
            }
        }

        MoveByDragDirection();
        ZoomByPinchDistance();
        //transform.Translate(0, 0, Mathf.Clamp(transform.position.z, zoomMin, zoomMax));
    }

    private void MoveByDragDirection()
    {
        transform.Translate(-dragDirection * dragSensitivity * Time.deltaTime, Space.World);
        dragDirection = Vector3.Lerp(dragDirection, Vector3.zero, decayRate * Time.deltaTime);
    }

    private void ZoomByPinchDistance()
    {
        transform.Translate(0, 0, pinchDelta * zoomSensitivity * Time.deltaTime, Space.Self);
        pinchDelta = Mathf.Lerp(pinchDelta, 0, decayRate * Time.deltaTime);
    }
}
