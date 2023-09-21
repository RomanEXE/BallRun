using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            ChangeMusic();
        }
    }

    private void ChangeMusic()
    {
        _audioSource.clip = _clips[Random.Range(0, _clips.Length)];
        _audioSource.Play();
    }
}