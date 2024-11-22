using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public void MoveToPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Function to set a specific camera size
    public void SetCameraSize(float size)
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = size;
    }
}