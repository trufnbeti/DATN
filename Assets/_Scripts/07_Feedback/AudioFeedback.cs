using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class AudioFeedback : MonoBehaviour
    {
        public AudioClip clip;
        public AudioSource targetAudioSource;
        [Range(0, 1)]
        public float volume = 1;

        public void PlayClip()
        {
            targetAudioSource.volume = this.volume;
            targetAudioSource.PlayOneShot(clip);
        }

        public void PlaySpecificClip(AudioClip clipToPlay = null)
        {
            if (clipToPlay == null)
                clipToPlay = clip;
            targetAudioSource.volume = this.volume;
            targetAudioSource.PlayOneShot(clipToPlay);
        }

    }
}
