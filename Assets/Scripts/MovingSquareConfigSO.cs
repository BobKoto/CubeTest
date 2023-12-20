using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingSquareConfig", menuName = "ScriptableObjects/MovingSquareConfig", order = 10)]
public class MovingSquareConfigSO : ScriptableObject
{
    public float speed;
    public float speedUpdateInterval;
  //  public int cyclesForPositionChange;
    public int changeOnCycleCount = 5;
    public float defaultRandomZposition = 50;
    public float minZStartPosition = 50;
    public float maxZStartposition = 54;
    public float minXStartPosition = -3;
    public float maxXStartposition = 3;
    public float minYStartPosition = 1f;
    public float maxYStartposition = -2f;
    // public float[] randomZStartPositions;

    public float GetRandomZStartPosition()
    {
        return Mathf.Floor(Random.Range(minZStartPosition, maxZStartposition));
    }
    public float GetRandomXStartPosition()
    {
        return Mathf.Floor(Random.Range(minXStartPosition, maxXStartposition));
    }
    public float GetRandomYStartPosition()
    {
        return Mathf.Floor (Random.Range(minYStartPosition, maxYStartposition));
    }
}
