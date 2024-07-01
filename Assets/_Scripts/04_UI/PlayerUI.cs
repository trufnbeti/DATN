using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class PlayerUI : MonoBehaviour
    {
        private HealthUI healthUI;
        private PointsUI pointsUI;
        private WeaponUI weaponUI;

        private void Awake()
        {
            healthUI = GetComponentInChildren<HealthUI>();
            pointsUI = GetComponentInChildren<PointsUI>();
            weaponUI = GetComponentInChildren<WeaponUI>();
        }

        public void InitializeMaxHealth(int maxHealth)
        {
            healthUI.Initialize(maxHealth);
        }

        public void SetHealth(int currentHealth)
        {
            healthUI.SetHealth(currentHealth);
        }

        public void SetPoints(int currentPoints)
        {
            pointsUI.SetPoints(currentPoints);
        }

        public void SetWeapon(Sprite weaponSprite)
        {
            weaponUI.SetWeaponImage(weaponSprite);
        }

        public void ToggleWeaponChangeTip(bool val)
        {
            weaponUI.ToggleWeaponTip(val);
        }

        public void ShowTutorialTip(string message)
        {

        }
    }
}
