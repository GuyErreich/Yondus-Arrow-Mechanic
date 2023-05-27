using UnityEngine;

public class ClipTimeLerper : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float startClipTime = 0f;
    [SerializeField] private float targetClipTime = 1f;
    [SerializeField, Range(0f, 1f)] private float currentTime = 0f;

    private float sourceVolume;
    public float CurrentTime { get => currentTime; set => currentTime = value; }


    private void Start()
    {
        sourceVolume = audioSource.volume;
        StopClip();
    }

    private float f = 0f;
    public bool isPlaying = false;

    private void Update()
    {
        if (CurrentTime == 0) {
            StopClip();
            return;
        }

        if (!isPlaying) {
            StartClip();
            return;
        }

        if(CurrentTime > 0) {
            // float t = 1 - (targetClipTime - CurrentTime * targetClipTime);
            float t = (targetClipTime - startClipTime) / CurrentTime;
            float lerpedTime = Mathf.Lerp(startClipTime, targetClipTime, t);
            audioSource.time = lerpedTime;
        }
    }

    private void StopClip() {
        audioSource.time = startClipTime;
        audioSource.volume = 0;
        audioSource.Stop();
        isPlaying = false;
    }

    private void StartClip() {
        audioSource.volume = 1 * sourceVolume;
        audioSource.Play();
        isPlaying = true;
    }
}
