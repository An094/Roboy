using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject canvas;
    //[SerializeField] private Animator menuAnimator;
    private void Start()
    {
        //AudioManager.Instance.PlayMusic("Rain");
        //AudioManager.Instance.MusicVolume(0.1f);
        if (PlayerPrefs.GetInt("PlayCutscene", 0) == 0)
        {
            PlayerPrefs.SetInt("PlayCutscene", 1);
            director.Play();
        }
        else
        {
            StartMenu();
        }
    }

    public void StartMenu()
    {
        canvas.SetActive(true);
        animator.Play("MenuTransition_Open");
    }

    public void PlayCutscene()
    {
        animator.Play("MenuTransition_Close");
        director.Play();
        DisableCanvas(0.5f);
    }

    public void Load(string name)
    {
        StartCoroutine(LoadScene(name));
    }
    private IEnumerator LoadScene(string name)
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(name);
    }

    private IEnumerator DisableCanvas(float duration)
    {
        yield return new WaitForSeconds(duration);
        canvas.SetActive(false);
    }

}
