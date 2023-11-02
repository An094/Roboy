using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableFloppy : MonoBehaviour
{
    [SerializeField] private GameObject m_floppyRef;
    private Animator m_animator;
    
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_animator.SetTrigger("Caught");
            m_floppyRef.SetActive(true);
            Destroy(gameObject, 0.3f);
        }
    }
}
