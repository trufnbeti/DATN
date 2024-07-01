using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Platformer
{
    public class AudioMixerAssigner : MonoBehaviour
    {
        public AudioMixerGroup groupToAssign;

        private void Start()
        {
            if (groupToAssign == null)
            {
                Debug.LogWarning("No audio mixer group assigned for " + transform.name);
                return;
            }
                
            AudioSource[] avatarAudio = GetComponentsInChildren<AudioSource>();
            foreach (var item in avatarAudio)
            {
                item.outputAudioMixerGroup = groupToAssign;
            }
        }
    }
}
