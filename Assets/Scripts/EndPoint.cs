using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPoint : MonoBehaviour
{
    [SerializeField] private Animator m_PlayerAnimator;
    [SerializeField] private float transitionTime = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        m_PlayerAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
