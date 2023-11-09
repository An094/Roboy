using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPoint : MonoBehaviour
{
    [SerializeField] private Animator m_LevelTrasitionrAnimator;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private int m_transitionLevel;
    [SerializeField] private int m_currentLevel;
    [SerializeField] private string nextLevel;
    private void Start()
    {
        m_LevelTrasitionrAnimator.SetInteger("Level", m_transitionLevel);
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
        m_LevelTrasitionrAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        m_LevelTrasitionrAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevel);
    }
}
