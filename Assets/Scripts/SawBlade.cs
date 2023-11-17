using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private Transform posA, posB;
    private PlayerController m_playerController;
    [SerializeField] private float m_speed;

    private Vector2 targetPos;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            m_playerController = player.GetComponent<PlayerController>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            m_playerController.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_playerController.Die();
        }
    }
}
