using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private PlayableDirector m_endingCutscene;
    [SerializeField] private LevelTransition m_levelTransition;
    public void PlayCutscene()
    {
        m_endingCutscene.Play();
    }

    public void OnEnd()
    { 
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        AudioManager.Instance.PlaySFX("Complete");
        m_levelTransition.OnEnd();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}
