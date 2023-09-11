using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            ChangeMusic();
        }
    }

    private void ChangeMusic()
    {
        _audioSource.clip = Resources.LoadAll<AudioClip>("Music")[Random.Range(0, 8)];
        _audioSource.Play();
    }
}