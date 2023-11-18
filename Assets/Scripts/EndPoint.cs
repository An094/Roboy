using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPoint : MonoBehaviour
{
    [SerializeField] private LevelTransition m_LevelTrasition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private int m_transitionLevel;
    [SerializeField] private int m_currentLevel;
    [SerializeField] private string nextLevel;
    [SerializeField] private Animator m_endpointAnimator;
    [SerializeField] private PlayerController m_player;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (m_currentLevel + 2 > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", m_currentLevel + 2);
            }


            StartCoroutine(LoadLevel(nextLevel));

        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        m_endpointAnimator.SetTrigger("Open");
        //yield return new WaitForSeconds(transitionTime);
        StartCoroutine(m_player.DoorIn());
        yield return new WaitForSeconds(2f);
        m_LevelTrasition.OnEnd();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        m_endpointAnimator.SetTrigger("Open");
        //yield return new WaitForSeconds(transitionTime);
        StartCoroutine(m_player.DoorIn());
        yield return new WaitForSeconds(2f);
        m_LevelTrasition.OnEnd();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevel);
    }
}
