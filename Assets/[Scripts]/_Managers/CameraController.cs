using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [HideInInspector] public Camera cam;

    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.3F;
    [SerializeField] Vector3 offset = new Vector3(0f, 5f, -5f);
    private Vector3 velocity = Vector3.zero;

    #region Singleton
    public static CameraController instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
        cam = GetComponent<Camera>();
    }
    #endregion

    private void Update() {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(offset);

        // Smoothly move and rotate the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
