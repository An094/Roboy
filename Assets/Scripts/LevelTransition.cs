using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Camera cam;
    private Vector2 startPos;
    private GameObject m_player;
    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = image.rectTransform.anchoredPosition;
        OnStart();
    }

    public void OnStart()
    {
        {
            Vector2 targetPos = WorldToUI(m_player);

            image.rectTransform.DOAnchorPos(targetPos, 1f);

            image.rectTransform.DOScale(new Vector3(0f, 0f, 0f), 1f);
            image.DOFade(0.5f, 1f).SetDelay(0.7f);

        };
    }

    public void OnEnd()
    {
        Vector2 targetPos = startPos;
        image.rectTransform.anchoredPosition = WorldToUI(m_player);
        {
            image.rectTransform.DOAnchorPos(targetPos, 1f);
            image.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 1f);
            image.DOFade(1f, 0.3f);

        };
    }

    // Update is called once per frame
    private Vector2 WorldToUI(GameObject obj)
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, obj.transform.position);

        Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);
        return anchoredPosition;
    }
}
