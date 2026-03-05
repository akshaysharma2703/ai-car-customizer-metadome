using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;

    public float distance = 8f;
    public float zoomSpeed = 5f;
    public float minDistance = 3f;
    public float maxDistance = 15f;

    public float rotationSpeed = 5f;

    float x = 0f;
    float y = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        // Rotate camera with mouse drag
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * rotationSpeed;
            y -= Input.GetAxis("Mouse Y") * rotationSpeed;

            // Limit vertical rotation
            y = Mathf.Clamp(y, 10f, 80f);
        }

        // Zoom with mouse wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;

        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}