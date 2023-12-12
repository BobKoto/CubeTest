using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
         {
           // Debug.Log("We got a hit in ScoreHits SENDING To EventBroadcaster...................");
            EventBroadcaster.UpdateScore(1);
            Destroy(this.gameObject);
        }
    }

}