using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingSquareConfig", menuName = "ScriptableObjects/MovingSquareConfig", order = 10)]
public class MovingSquareConfigSO : ScriptableObject
{
    public float speed;
    public float speedUpdateInterval;
    public int cyclesForPositionChange;
    public int changeOnCycleCount;
}
