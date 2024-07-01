using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class InstantiateUtil : MonoBehaviour
    {
        public GameObject objectToInstantiate;

        public void CreateObject()
        {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    }
}
