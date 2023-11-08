using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Animator m_playerAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_animator.SetTrigger("Catch");
            m_playerAnimator.SetTrigger("Die");
        }
    }

}
