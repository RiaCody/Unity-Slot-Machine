
using UnityEngine;

/// <summary>
/// Simple audio wrapper. Assign an AudioSource and optional clips in Inspector.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip spinClip;
    public AudioClip winClip;

    public void PlaySpin()
    {
        if (source != null && spinClip != null)
            source.PlayOneShot(spinClip);
    }

    public void PlayWin()
    {
        if (source != null && winClip != null)
            source.PlayOneShot(winClip);
    }
}
