using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HitFlashFeedback : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private float feebdackTime = 0.1f;


        public void PlayFeedback()
        {
            if (spriteRenderer == null || spriteRenderer.material.HasProperty("_MakeSolidColor") == false)
            {
                return;
            }
            ToggleMaterial(1);
            StopAllCoroutines();
            StartCoroutine(ResetColor());
        }

        IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(feebdackTime);
            ToggleMaterial(0);
        }

        private void ToggleMaterial(int val)
        {
            val = Mathf.Clamp(val, 0, 1);
            spriteRenderer.material.SetInt("_MakeSolidColor", val);
        }
    }
}
