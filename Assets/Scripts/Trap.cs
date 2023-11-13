using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    enum TrapType
    {
        None,
        Catchable
    }
    [SerializeField] private Animator m_animator;
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private TrapType m_type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (m_type.Equals(TrapType.Catchable))
            {
                m_animator.SetTrigger("Catch");
            }
            m_playerController.Die();
        }
    }

}
