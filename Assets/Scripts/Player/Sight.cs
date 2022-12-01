using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        transform.position = RayToPointOnFloor(mainCamera.ScreenPointToRay(Input.mousePosition));
        
        Vector3 RayToPointOnFloor(Ray ray, float floor = 0f)
        {
            float lamda = (floor - ray.origin.y) / ray.direction.y;
            return ray.origin + lamda * ray.direction;
        }
    }
}
