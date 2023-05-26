using UnityEngine;

public class ClipTimeLerper : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float startClipTime = 0f;
    [SerializeField] private float targetClipTime = 1f;
    [SerializeField] private float duration = 1f;
    [SerializeField, Range(0f, 1f)] private float currentTime = 0f;

    public float CurrentTime { get => currentTime; set => currentTime = value; }

    private float GetCurrentTime()
    {
        return currentTime;
    }

    private void Start()
    {
        audioSource.time = startClipTime;
    }

    private float f = 0f;
    public bool isPlaying = false;
    private void Update()
    {
        if (currentTime == 0) {
            audioSource.volume = 0;
            audioSource.time = 0;
            // audioSource.Stop();
            return;
        }

        if(currentTime > 0) {
            // if (!isPlaying) {
                // audioSource.Play();
                // audioSource.loop = true;
                audioSource.volume = 1;
                // isPlaying = true;
            // }
        }
            

        // if (currentTime < duration)
        // {
        //     // audioSource.Play();
        //     // float t = currentTime / duration;
        //     // float lerpedTime = Mathf.Lerp(startClipTime, targetClipTime, t);
        //     // audioSource.time = lerpedTime;
        // }
        // else
        // {
        //     // audioSource.time = targetClipTime;
        //     audioSource.Stop();
        //     // audioSource.volume = 0;
        //     // isPlaying = false;
        // }
    }
}
