using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SaveSystemManager : MonoBehaviour
    {
        public void ResetSaveData()
        {
            SaveSystem.ResetSaveData();
        }
    }
}
