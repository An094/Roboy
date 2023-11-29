using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class Dog : MonoBehaviour
{
    [SerializeField] private EndGameHandler m_endGameHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_endGameHandler.PlayCutscene();
        }
    }
    
}
