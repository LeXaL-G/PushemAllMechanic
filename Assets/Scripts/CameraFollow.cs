using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    //[SerializeField] private Quaternion rotateOffset;
    //[SerializeField] private float rotateSpeed = 5;
    [SerializeField] private float chaseSpeed=5;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, chaseSpeed * Time.deltaTime);
        //transform.rotation=Quaternion.RotateTowards(transform.rotation,target.rotation*rotateOffset,rotateSpeed*Time.deltaTime);
    }
}
