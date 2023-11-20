using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator animator;

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
}
