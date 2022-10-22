using System;
using Player;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(CrashDetector))]
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip crashSFX;

        private AudioSource _audioSource;

        private void Start()
        {
            AssignCallback();
            GetComponents();
        }

        private void OnDestroy()
        {
            GetComponent<CrashDetector>().OnCrashed -= PlayCrash;
        }

        private void AssignCallback()
        {
            GetComponent<CrashDetector>().OnCrashed += PlayCrash;
        }

        private void GetComponents()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void PlayCrash()
        {
            _audioSource.PlayOneShot(crashSFX);
        }
    }
}