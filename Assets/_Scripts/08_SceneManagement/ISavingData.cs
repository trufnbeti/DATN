using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public interface ISavingData 
    {
        void SaveData();
        void LoadData();
    }
}
