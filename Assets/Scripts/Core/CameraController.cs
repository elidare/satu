using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D bounds;
    private Camera cam;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private float _minX, _maxX;
    private bool isFollowing;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        _minX = bounds.bounds.min.x;
        _maxX = bounds.bounds.max.x;
        isFollowing = true;
    }

    private void Update()
    {
        Vector3 targetPosition = transform.position;

        if (isFollowing)
        {
            float cameraHalfWidth = cam.orthographicSize * ((float)Screen.width / Screen.height);

            float clampedX = Mathf.Clamp(player.position.x, _minX + cameraHalfWidth, _maxX - cameraHalfWidth);
            targetPosition = new Vector3(clampedX, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
