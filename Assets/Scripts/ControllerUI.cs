using UnityEngine;
using System.Collections;

public class ControllerUI : MonoBehaviour 
{
    public Transform startPoint;
    public Transform endPoint;
    public enum UseCase { Auto, Manual}
    public UseCase useCase;
    [SerializeField]
    private float _moveSpeed = 1;
    private bool _return;
    [SerializeField]
    private bool _switch = true;
    private Rigidbody _platformRigidBody = null;
    public Transform _platform;
    
    void Start()
    {
        _platformRigidBody = _platform.transform.GetComponent<Rigidbody>();
        _platformRigidBody.mass = 200;
    }
    
    public void SwitchState()
    {
        _switch = (_switch == true) ? false : true;
    }
    
    void SetState(bool state)
    {
        _switch = state;
        
    }
    
    void FixedUpdate()
    {
        if (useCase == UseCase.Auto)
        {
            if (_platform.position == endPoint.position) _return = true;
            if (_platform.position == startPoint.position) _return = false;
            
            if (_return) _platform.position = Vector3.MoveTowards(_platform.position, startPoint.position, _moveSpeed * Time.fixedDeltaTime);
            if (!_return) _platform.position = Vector3.MoveTowards(_platform.position, endPoint.position, _moveSpeed * Time.fixedDeltaTime);
        }
        if (useCase == UseCase.Manual)
        {          
            if (_switch) _platform.position = Vector3.MoveTowards(_platform.position, startPoint.position, _moveSpeed * Time.fixedDeltaTime);
            if (!_switch) _platform.position = Vector3.MoveTowards(_platform.position, endPoint.position, _moveSpeed * Time.fixedDeltaTime);       
        }
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startPoint.position, transform.localScale);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPoint.position, transform.localScale);
    }
}