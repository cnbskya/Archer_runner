using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed;
    public Vector3 DefaultOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOn)
        {
            DefaultOffset = new Vector3(0, 4, -4);
            CameraRePosition(DefaultOffset);
        }
    }

    public void CameraRePosition(Vector3 DefaultOffset)
    {
        Vector3 desiredPosition = target.transform.position + DefaultOffset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
