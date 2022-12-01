using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    private Rigidbody myRigitbody;
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigitbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LookRotation2D();
    }

    void LookRotation()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void LookRotation2D()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void RigidbodyRotation()
    {
        // myRigitbody.rotation.
    }
    
    // может через джоинты?
}
