using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CMCamerConfinerUtil : MonoBehaviour
    {
        public PolygonCollider2D cameraConfiner;
        public CinemachineConfiner cm_confiner;

        public void SetConfiner()
        {
            cm_confiner.m_BoundingShape2D = cameraConfiner;
        }
    }
}
