using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool Caught = false;
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
        if(collision.CompareTag("Player") && !Caught)
        {
            if (m_type.Equals(TrapType.Catchable))
            {
                Caught = true;
                m_animator.SetTrigger("Catch");
            }
            m_playerController.Die();
        }
    }

}
