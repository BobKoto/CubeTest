using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHit : MonoBehaviour
{  //Component of Sphere(s) in prefab MovingSquare
    SphereCollider myCollider;
    MeshRenderer meshrenderer;
    //GameObject buttonRestart;
    public ScriptableAudio scriptableAudio;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<SphereCollider>();
        meshrenderer = gameObject.GetComponent<MeshRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
         {
           // Debug.Log("We got a hit in ScoreHits SENDING To EventBroadcaster...................");
            EventBroadcaster.UpdateScore(1);
            if (myCollider) myCollider.enabled = false;
            if (meshrenderer) meshrenderer.enabled = false;
            SendMessage("ResetCanMove");
            PlayRandomClip();
        }
    }

    void PlayRandomClip()
    {
        AudioClip randomClip = scriptableAudio.GetRandomClip();

        if (randomClip != null)
        {
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
        public void OnRestartPressedEvent()
    {
        if (myCollider) myCollider.enabled = true;
        if (meshrenderer) meshrenderer.enabled = true;
        //buttonRestart = GameObject.Find("ButtonRetart");
        //if (buttonRestart) buttonRestart.SetActive(false);
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