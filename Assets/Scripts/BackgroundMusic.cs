using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private bool _canPlayMusic;

    private void OnEnable()
    {
        Actions.OnGameStarted += () => _canPlayMusic = true;
        Actions.OnGameEnd += delegate
        {
            _canPlayMusic = false;
            if (_audioSource)
                _audioSource.Stop();
        };
    }

    private void Update()
    {
        if (_canPlayMusic && !_audioSource.isPlaying)
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