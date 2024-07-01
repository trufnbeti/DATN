using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CameraManager : MonoBehaviour
    {
        public CinemachineVirtualCamera CM_camera;

        private void Awake()
        {
            if (CM_camera == null)
                CM_camera = FindObjectOfType<CinemachineVirtualCamera>();
        }

        public void SetCameraTarget(Transform playerTransform)
        {
            CM_camera.LookAt = playerTransform;
            CM_camera.Follow = playerTransform;
        }
    }
}
