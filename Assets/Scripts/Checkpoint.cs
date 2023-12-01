using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform m_respawnPoint;
    private PlayerController m_playerController;
    private Animator m_animator;
    private  Light2D light2D;
    private bool TurnedOn = false;

    enum CheckpointType
    {
        Computer,
        Floppy
    }

    [SerializeField] private CheckpointType type;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            m_playerController = player.GetComponent<PlayerController>();
        }
        if (type == CheckpointType.Computer)
        {
            m_animator = GetComponent<Animator>();
            light2D = GetComponent<Light2D>();
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !TurnedOn)
        {
            TurnedOn = true;
            if(type == CheckpointType.Computer)
            {
                StartCoroutine(TurnOn());
            }
            else
            {
                m_playerController.respawnPosition = m_respawnPoint.position;
            }
        }
    }

    IEnumerator TurnOn()
    {
        m_animator.SetTrigger("TurnOn");
        AudioManager.Instance.PlaySFX("TurnOn");
        m_playerController.respawnPosition = m_respawnPoint.position;
        yield return new WaitForSeconds(0.5f);
        m_animator.SetBool("On", true);
        light2D.enabled = true;
    }
}
