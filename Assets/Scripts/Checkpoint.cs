using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Transform m_respawnPoint;
    private bool TurnedOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !TurnedOn)
        {
            TurnedOn = true;
            StartCoroutine(TurnOn());
        }
    }

    IEnumerator TurnOn()
    {
        m_animator.SetTrigger("TurnOn");
        m_playerController.respawnPosition = m_respawnPoint.position;
        yield return new WaitForSeconds(0.5f);
        m_animator.SetBool("On", true);
    }
}