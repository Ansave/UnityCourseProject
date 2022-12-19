using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyWobbling : MonoBehaviour
{
    [SerializeField] public GameObject spring;
    [SerializeField] public float wobblingScale;
    
    // Update is called once per frame
    void LateUpdate()
    {
        Wobbling();
    }
    
    private void Wobbling()
    {
        Vector3 relarivePosition = spring.transform.position - transform.position;
        Vector3 wobbling = new Vector3(-relarivePosition.z, 0, relarivePosition.x) * wobblingScale;
        transform.localRotation = Quaternion.identity; // Reset rotation
        transform.Rotate(wobbling,Space.World);
    }
}
