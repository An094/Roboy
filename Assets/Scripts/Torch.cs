using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [SerializeField] private Light2D m_light;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flick());
    }

    private IEnumerator Flick()
    {
        while(true)
        {
            float duration = Random.RandomRange(0.1f, 0.2f);
            float intensity = Random.RandomRange(1.5f, 4f);
            m_light.intensity = intensity;
            yield return new WaitForSeconds(duration);
        }
    }
}
