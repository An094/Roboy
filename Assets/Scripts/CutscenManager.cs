using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutscenManager : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Image image;
    [SerializeField] private Camera cam;
    private Vector2 targetPos;

    private void Start()
    {
        targetPos = image.rectTransform.position;
        image.rectTransform.anchoredPosition = WorldToUI(startPos.position);
    }
    public void OnEnd()
    {
        SceneManager.LoadScene("Level1");
    }

    private Vector2 WorldToUI(Vector2 pos)
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, pos);

        Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);
        return anchoredPosition;
    }
}
