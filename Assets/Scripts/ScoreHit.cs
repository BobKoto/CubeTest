using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHit : MonoBehaviour
{
    SphereCollider myCollider;
    MeshRenderer meshrenderer;
    GameObject buttonRestart;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<SphereCollider>();
        meshrenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
         {
           // Debug.Log("We got a hit in ScoreHits SENDING To EventBroadcaster...................");
            EventBroadcaster.UpdateScore(1);
            if (myCollider) myCollider.enabled = false;
            if (meshrenderer) meshrenderer.enabled = false;
        }
    }
    public void OnRestartPressedEvent()
    {
        if (myCollider) myCollider.enabled = true;
        if (meshrenderer) meshrenderer.enabled = true;
        buttonRestart = GameObject.Find("ButtonRetart");
        if (buttonRestart) buttonRestart.SetActive(false);
    }
    private void OnEnable()
    {
        EventBroadcaster.OnRestartPressed += OnRestartPressedEvent;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnRestartPressed -= OnRestartPressedEvent;
    }
}