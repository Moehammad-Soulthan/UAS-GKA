using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform lookAt; // Fox
    public Vector3 offset = new Vector3(0, 5.0f, 11.0f);

    private void Start() {
        transform.position = lookAt.position + offset;
    }

    private void LateUpdate() {
        Vector3 desiredPosition = lookAt.position + offset;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }

    public void setPosition() {
        offset.z += 1.2f;
    }
}
