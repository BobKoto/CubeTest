using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "ScriptableObjects/AudioClips", order = 10)]
public class ScriptableAudio : ScriptableObject
{
    public AudioClip[] audioClips;

    public AudioClip GetRandomClip()
    {
        if (audioClips == null || audioClips.Length == 0)
        {
            Debug.LogError("AudioClipsData is not properly set up. Add audio clips.");
            return null;
        }

        int randomIndex = Random.Range(0, audioClips.Length);
        return audioClips[randomIndex];
    }
}