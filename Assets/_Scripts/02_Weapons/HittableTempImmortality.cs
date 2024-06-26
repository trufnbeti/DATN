using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HittableTempImmortality : MonoBehaviour, IHittable
    {
        public Collider2D[] colliders = new Collider2D[0];
        public float immortalityTime = 1;

        public SpriteRenderer spriteRenderer;
        public float flashDelay = 0.1f;
        [Range(0,1)]
        public float flashAlpha = 0.5f;


        [Header("For debug purposes")]
        public bool isImmortal = false;

        private void Awake()
        {
            if (colliders.Length == 0)
                colliders = GetComponents<Collider2D>();
        }
        public void GetHit(GameObject opponent, int damageAmount)
        {
            ToggleColliders(false);
            StartCoroutine(ResetColliders());
            StartCoroutine(Flash(flashAlpha));
        }

        IEnumerator ResetColliders()
        {
            yield return new WaitForSeconds(immortalityTime);
            StopAllCoroutines();
            ToggleColliders(true);
            ChangeSpriteRendererColorAlpha(1);
        }

        IEnumerator Flash(float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            ChangeSpriteRendererColorAlpha(alpha);
            yield return new WaitForSeconds(flashDelay);
            StartCoroutine(Flash(alpha < 1 ? 1 : flashAlpha));

        }

        private void ChangeSpriteRendererColorAlpha(float alpha)
        {
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }

        private void ToggleColliders(bool val)
        {
            isImmortal = !val;
            foreach (var collider in colliders)
            {
                collider.enabled = val;
            }
        }
    }
}
