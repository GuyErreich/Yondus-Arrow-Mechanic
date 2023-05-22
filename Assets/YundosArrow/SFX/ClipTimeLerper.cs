using UnityEngine;

public class ClipTimeLerper : MonoBehaviour
{
    public AudioSource audioSource;
    public float startClipTime = 0f;
    public float targetClipTime = 1f;
    public float duration = 1f;

    [SerializeField, Range(0f, 1f)] private float currentTime = 0f;

    private void Start()
    {
        audioSource.time = startClipTime;
    }

    private void Update()
    {
        // currentTime += Time.deltaTime;

        if (currentTime < duration)
        {
            // enabled = true;
            float t = currentTime / duration;
            float lerpedTime = Mathf.Lerp(startClipTime, targetClipTime, t);
            audioSource.time = lerpedTime;
        }
        else
        {
            audioSource.time = targetClipTime;
            // enabled = false; // Disable the script when the interpolation is complete
        }
    }
}
