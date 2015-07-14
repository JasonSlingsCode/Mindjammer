// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
    public Camera TargetCamera;
    
    void Start()
    {
        //transform.Rotate( 180,0,0 );
    }
    
    void Update()
    {
        
        Vector3 v = Camera.main.transform.position - transform.position;
        
        v.x = v.z = 0.0f;
        
        transform.LookAt( Camera.main.transform.position - v );
        
        transform.rotation =(Camera.main.transform.rotation); // Take care about camera rotation
        
    }
}
