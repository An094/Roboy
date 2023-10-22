using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "New FloppyData", menuName = "FloppyData")]
public class FloppyData : ScriptableObject
{
    public enum FloppyType
    {
        Object,
        Condition,
        Statement
    }
    public string m_DiskName;
    public Sprite m_Sprite;
    public FloppyType m_Type;
}
