using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableFloppy : MonoBehaviour
{
    [SerializeField] private GameObject m_floppyRef;
    private Animator m_animator;

    private bool WasCaught = false;
    
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !WasCaught)
        {
            WasCaught = true;
            m_animator.SetTrigger("Caught");
            AudioManager.Instance.PlaySFX("Catch");
            m_floppyRef.SetActive(true);
            m_floppyRef.GetComponent<DraggableFloppy>().Appear();
            Destroy(gameObject, 0.3f);
        }
    }
}
