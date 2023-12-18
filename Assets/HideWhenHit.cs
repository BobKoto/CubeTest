using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenHit : MonoBehaviour
{  //Component of prefab MovingSquare(s), hide the square "loop(s)" when hit, unhide on restart press
    BoxCollider myCollider;
    public MeshRenderer[] meshrenderers;
    //GameObject buttonRestart;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<BoxCollider>();
        meshrenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        Debug.Log(this.name + " Reports " + meshrenderers.Length + " meshes");
    }

    private void OnReportHitEvent()
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
            if (myCollider) myCollider.enabled = false;
            for (int i = 0; i < meshrenderers.Length; i++)
            {
                //if (meshrenderers[i]) meshrenderers[i].enabled = false;
                meshrenderers[i].enabled = false;
                Debug.Log(this.name + " Reports " + meshrenderers[i].name + " disabled?");
            }
        //}
    }

    public void OnRestartPressedEvent()
    {
        if (myCollider) myCollider.enabled = true;
        for (int i = 0; i < meshrenderers.Length; i++)
        {
            if (meshrenderers[i]) meshrenderers[i].enabled = true;
        }
    }
    private void OnEnable()
    {
        EventBroadcaster.OnRestartPressed += OnRestartPressedEvent;
        EventBroadcaster.ReportHitEvent += OnReportHitEvent;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnRestartPressed -= OnRestartPressedEvent;
        EventBroadcaster.ReportHitEvent -= OnReportHitEvent;
    }
}