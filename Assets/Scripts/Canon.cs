using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject m_CanonBallPref;
    [SerializeField] private Transform m_firePoint;
    private Animator m_animator;
    private bool CanFire = false;
    private bool WasTrigger = false;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !WasTrigger)
        {
            Debug.Log("Trigger");
            WasTrigger = true;
            CanFire = true;

            StartCoroutine(Fire());
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && WasTrigger)
    //    {
    //        WasTrigger = false;
    //        CanFire = false;
    //    }
    //}

    //private void Update()
    //{
    //    if(CanFire)
    //    {
    //        StartCoroutine(Fire());
    //    }
    //}

    IEnumerator Fire()
    {
        WaitForSeconds wait = new WaitForSeconds(4f);
        while (CanFire)
        {
            CanFire = false;
            m_animator.SetTrigger("Fire");
            GameObject canonball = Instantiate(m_CanonBallPref, m_firePoint.position, transform.rotation);
            Vector2 projectileDir = new Vector2(transform.localScale.x * -1, 0);
            canonball.GetComponent<Rigidbody2D>().AddForce(projectileDir * 3.0f, ForceMode2D.Impulse);
            yield return wait;
            CanFire = true;
        }

    }
}
