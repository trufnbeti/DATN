using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ChangeLayerUtil : MonoBehaviour
    {
        public int layerIndex = 2;
        public GameObject targetGameObject;

        public void ChangeLayer()
        {
            targetGameObject.layer = layerIndex;
        }

        public void ChangeLayer(int customIndex)
        {
            targetGameObject.layer = customIndex;
        }
    }
}
