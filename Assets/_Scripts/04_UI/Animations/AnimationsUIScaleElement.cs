using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class AnimationsUIScaleElement : MonoBehaviour
    {
        [SerializeField]
        private RectTransform element;
        [SerializeField]
        private float animationEndScale;
        [SerializeField]
        private float animationTime;
        private float baseScaleValue;
        private Vector3 baseScale, endScale;
        [SerializeField]
        private bool playConstantly = false;

        private Sequence sequence;

        private void Start()
        {

            baseScale = element.localScale;
            endScale = Vector3.one * animationEndScale;
            
            
            if (playConstantly)
            {
                sequence =
                DOTween.Sequence()
                .Append(element.DOScale(baseScale, animationTime))
                .Append(element.DOScale(endScale, animationTime));
                sequence.SetLoops(-1, LoopType.Yoyo);
                sequence.Play();
            }
                
        }
        public void PlayAnimation()
        {
            StopAllCoroutines();
            element.localScale = baseScale;
            StartCoroutine(ScaleImage(true));

        }

        IEnumerator ScaleImage(bool scaleUp)
        {
            float time = 0;
            //float delta = animationEndScale - 1;
            while (time < animationTime)
            {
                time += Time.deltaTime;
                var value = (time / animationTime);// * delta;
                Vector3 currentScale;
                if (scaleUp)
                {
                    currentScale = baseScale + value*(endScale-baseScale);
                }
                else
                {
                    currentScale = endScale - value * (endScale - baseScale);
                }
                element.localScale = currentScale;
                yield return null;
            }

            element.localScale = scaleUp ? endScale : baseScale;
            if (playConstantly || scaleUp == true)
                StartCoroutine(ScaleImage(!scaleUp));
        }

        private void OnDestroy()
        {
            if(sequence !=null)
                sequence.Kill();
        }
    }
}
