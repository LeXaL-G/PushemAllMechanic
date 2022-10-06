using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 500,forcePower=100;

    private Touch _touch;
    private Rigidbody rb;
    
    private Vector3 _touchDown;
    private Vector3 _touchUp;
    private bool dragStart;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y<0.7f)
        {
            Time.timeScale = 0;
        }
        if (Input.touchCount>0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase==TouchPhase.Began)
            {
                dragStart = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;
            }
        }

        if (dragStart)
        {
            if (_touch.phase==TouchPhase.Moved)
            {
                _touchDown = _touch.position;
            }

            if (_touch.phase==TouchPhase.Ended)
            {
                _touchDown = _touch.position;
                dragStart = false;
            }
            gameObject.transform.rotation=Quaternion.RotateTowards(transform.rotation,CalculateRotation(),rotationSpeed*Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = -(_touchDown - _touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(collision.transform.forward*forcePower);
        }
    }
}