using System;
using UnityEngine;

public class RepulsiveManager : MonoBehaviour
{
    [SerializeField] private float forcePower = 100;
    [SerializeField] private GameObject enemy,player;
    Touch touch;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(Input.touchCount>0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                enemy.GetComponent<Rigidbody>().AddForce(transform.forward * forcePower);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                player.GetComponent<Rigidbody>().AddForce(collision.transform.forward * forcePower);
            }
        }
    }
}
