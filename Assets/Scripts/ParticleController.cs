using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [SerializeField] ParticleSystem landingParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.5f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] PlayerController playerController;
    float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(playerController.deltaMovement) > 0f && Mathf.Abs(playerController.m_rb.velocity.y) == 0)
        {
            if (counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

    public void PlayLandingEffect()
    {
        landingParticle.Play();
    }
}
