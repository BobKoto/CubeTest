using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingSquareConfig", menuName = "ScriptableObjects/MovingSquareConfig", order = 10)]
public class MovingSquareConfigSO : ScriptableObject
{
    public float speed;
    public float speedMin;
    public float speedMax;
    public float speedUpdateInterval;
    public float distanceOffset;
  //  public int cyclesForPositionChange;
    public int changeOnCycleCount = 5;
    public float defaultRandomZposition = 50;
    public float minZStartPosition = 50;
    public float maxZStartposition = 54;
    public float minXStartPosition = -3;
    public float maxXStartposition = 3;
    public float minYStartPosition = 1f;
    public float maxYStartposition = -2f;
    [Header ("Max 3 elements/vector3s; descending on z")]
    public Vector3[] positionPointsGroup1;
    public Vector3[] positionPointsGroup2;
    public Vector3[] positionPointsGroup3;
    [Range (0,1)]
    public float setTimeScale = 1f;
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
