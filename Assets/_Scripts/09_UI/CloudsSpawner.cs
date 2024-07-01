using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Platformer
{
    public class CloudsSpawner : MonoBehaviour
    {
        
        [SerializeField]
        private float width = 10, length = 10;
        [SerializeField]
        private Color gizmoColor = new Color(1, 0, 0, 0.2f);
        [SerializeField]
        private bool showGizmo = true;
        [SerializeField]
        List<Cloud> cloudPrefabs = new List<Cloud>();
        private RectTransform myRectTransform;

        public List<Cloud> currentCloud = new List<Cloud>();
        public Transform fronCloudParent;

        private void Awake()
        {
            myRectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            foreach (Transform item in transform)
            {
                item.GetComponent<Cloud>().Initialize(width / 2 + 50, SpawnClouds);
            }
            foreach (Transform item in fronCloudParent)
            {
                item.GetComponent<Cloud>().Initialize(width / 2 + 50, SpawnClouds);
            }
        }

        public void SpawnClouds()
        {
            Vector3 position = GetRandomPosition();
            Transform parent = this.transform;
            
            int cloudIndex = Random.Range(0, cloudPrefabs.Count);
            Cloud cloud = cloudPrefabs[cloudIndex];
            var scale = cloud.GetCloudScale();
            var cloudObject = Instantiate(cloud.gameObject);
            var rectTransform = cloudObject.GetComponent<RectTransform>();
            rectTransform.position = position;
            rectTransform.localScale = Vector3.one * scale;

            if (Random.value > 0.5)
            {
                parent = fronCloudParent;
                cloud.speed = 50;
                rectTransform.localScale += Vector3.one / 2f;
            }

            rectTransform.SetParent(parent);
            
            cloudObject.GetComponent<Cloud>().Initialize(width / 2 + 50, SpawnClouds);



        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(myRectTransform.position.x - width / 2 + Random.Range(0,50), Random.Range(myRectTransform.transform.position.y - length / 2, myRectTransform.transform.position.y + length / 2), 1);
        }

        private void OnDrawGizmos()
        {
            if (showGizmo)
            {
                Gizmos.color = gizmoColor;
                RectTransform rectTransform = GetComponent<RectTransform>();
                //Vector3 BottomPosition = Vector3.zero;
                //RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, new Vector2(0, rectTransform.rect.height), null, out BottomPosition);
                Gizmos.DrawCube(rectTransform.position, new Vector2(width, length));

            }
            
        }
    }

    
}
