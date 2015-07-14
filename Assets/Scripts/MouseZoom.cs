using UnityEngine;
using System.Collections;

public class MouseZoom : MonoBehaviour
{
    public Transform target;
    private float currentDistance;
    private float desiredDistance;
    public float maxDistance = 20;
    public float minDistance = .6f;
    public int zoomRate = 40;
    public float zoomDampening = 5.0f;
    private Vector3 position;
    private Quaternion rotation;
    public Vector3 targetOffset;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        ////////Orbit Position
        
        // affect the desired Zoom distance if we roll the scrollwheel
        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
        //clamp the zoom min/max
        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        // For smoothing of the zoom, lerp distance
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
        
        // calculate position based on the new currentDistance 
        position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
        transform.position = position;
    }
}
