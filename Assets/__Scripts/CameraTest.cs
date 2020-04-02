
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform target; //this is what the camera will follow

    public float smoothSpeed = 0.125f; //the higher this value, the faster the camera will lock on the the target

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = desiredPosition;

    }
}
