using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Floppy : MonoBehaviour
{
    [SerializeField] private FloppyData m_data;

    [SerializeField] private TMP_Text m_text;

    [SerializeField] private SpriteRenderer m_sprite;
    // Start is called before the first frame update
    void Start()
    {
        m_text.text = m_data.name;
        m_sprite.sprite = m_data.m_Sprite;
    }

    // Update is called once per frame
    public FloppyData.FloppyType GetFloppyType()
    {
        return m_data.m_Type;
    }
}
