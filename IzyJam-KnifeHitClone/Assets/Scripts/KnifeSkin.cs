using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class KnifeSkin : ScriptableObject
{
    public int index;
    public Sprite icon;
    public GameObject gfx;
}
