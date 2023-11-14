using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private GameObject m_player;
    private Animator m_ani;
    private Rigidbody2D m_rb;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_ani = m_player.GetComponent<Animator>();
        m_rb = m_player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(m_player.transform.position, transform.position) > 0.3f)
            {

                StartCoroutine(PortalIn());
            }

        }
    }

    IEnumerator PortalIn()
    {
        m_rb.simulated = false;
        m_ani.Play("Robot_PortalIn");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        m_player.transform.position = destination.position;
        m_ani.Play("Robot_PortalOut");
        yield return new WaitForSeconds(0.5f);
        m_ani.SetTrigger("PortalOut");
        m_rb.simulated = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while(timer < 0.5f)
        {
            m_player.transform.position = Vector2.MoveTowards(m_player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }

}
