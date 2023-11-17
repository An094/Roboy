using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatformer : MonoBehaviour
{
    [SerializeField] float force;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Break();
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Projectile"))
    //    {
    //        Destroy(collision.gameObject);
    //        Break();
    //    }
    //}


    private void Break()
    {
        //Rigidbody2D[] children = GetComponentsInChildren<Rigidbody2D>();
        //foreach(Rigidbody2D rb in children)
        //{
        //    float y = Random.Range(-180, 180);
        //    Vector3 angle = new Vector3(0, y, 0);
        //    Quaternion windOrientation = Quaternion.Euler(angle);
        //    Vector3 windDirection = windOrientation * Vector3.forward;
        //    rb.AddForce(windDirection, ForceMode2D.Impulse);
        //}
        GetComponent<SpriteRenderer>().enabled = false;
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform obj = transform.GetChild(i);
            obj.gameObject.SetActive(true);
            Rigidbody2D rb2d = obj.GetComponent<Rigidbody2D>();
            float z = Random.Range(0, 360);
            Vector3 angle = new Vector3(0, 0, z);
            Quaternion windOrientation = Quaternion.Euler(angle);
            Vector3 windDirection = windOrientation * Vector3.forward;
            rb2d.AddForce(windDirection * force, ForceMode2D.Impulse);
            Destroy(obj.gameObject, 2f);

        }
        Destroy(gameObject, 2f);
    }
}
