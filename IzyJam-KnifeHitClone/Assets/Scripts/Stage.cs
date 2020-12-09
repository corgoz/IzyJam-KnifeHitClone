using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "Stage")]
public class Stage : ScriptableObject
{
    public float rotationSpeed;
    public AnimationCurve curve;

    public int numberOfKnifes;
}
