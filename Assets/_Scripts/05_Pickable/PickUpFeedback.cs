using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PickUpFeedback : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource.GetComponent<AudioSource>();
        }

        public void PlayFeedbackSound()
        {
            audioSource.Play();
        }

        public void PlayFeedbackSound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
