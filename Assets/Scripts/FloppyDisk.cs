using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "New FloppyDisk", menuName = "FloppyDisk")]
public class FloppyDisk : ScriptableObject
{
    public enum FloppyDiskType
    {
        Normal,
        Condition,
        Statement
    }
    public string m_DiskName;
    public Sprite m_Sprite;
    public FloppyDiskType m_Type;
}
