using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Movespeed = 0.1f;

    private void Update()
    {
        this.transform.Translate(Vector3.back * Movespeed * Time.deltaTime);
        Destroy(gameObject, 20);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wallend") == true)
        {
            Destroy(this.gameObject);
        }  if (collision.gameObject.CompareTag("obstacle") == true)
        {
            Destroy(this.gameObject);
        }
    }
}
