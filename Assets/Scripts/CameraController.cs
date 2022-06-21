using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    public Transform cameraTransform;

    public float moveSpeed = 50f;
    public float movementTime;
    public float rotationSpeed;
    public float zoomSpeed;
    public float minZoom, maxZoom;

    private Vector3 cameraOffsetDirection;

    private Vector3 newPosition;
    private Quaternion newRotation;
    private float newZoom;

    private Vector2 translate;
    private float rotate;
    private float zoom;
    

    private void Start() {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition.magnitude;
        cameraOffsetDirection = cameraTransform.localPosition.normalized;
    }

    void OnTranslate(InputValue value) {
        translate = value.Get<Vector2>();
    }

    void OnRotate(InputValue value) {
        rotate = value.Get<float>();
    }

    void OnZoom(InputValue value) {
        zoom = value.Get<float>();
    }

    private void Update() {
        var speed = moveSpeed * newZoom / 10f;
        newPosition += transform.forward * translate.y * speed * Time.deltaTime;
        newPosition += transform.right * translate.x * speed * Time.deltaTime;

        newRotation *= Quaternion.Euler(0f, rotate * rotationSpeed * Time.deltaTime, 0f);

        newZoom *= 1 - zoom * zoomSpeed * Time.deltaTime;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraOffsetDirection * newZoom, Time.deltaTime * movementTime);
    }
}
