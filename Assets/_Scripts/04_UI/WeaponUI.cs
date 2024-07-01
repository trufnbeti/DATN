using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField]
        private Image weaponSprite;
        [SerializeField]
        private GameObject weaponSwapTip;

        public UnityEvent SwapWeaponEvent, ToggleWeaponTipUI;

        private void Start()
        {
            weaponSprite.enabled = false;
            weaponSprite.sprite = null;
            weaponSwapTip.SetActive(false);
        }

        internal void SetWeaponImage(Sprite weaponSprite)
        {
            if (this.weaponSprite.sprite == weaponSprite)
                return;
            this.weaponSprite.enabled = true;
            this.weaponSprite.sprite = weaponSprite;
            SwapWeaponEvent?.Invoke();
        }

        internal void ToggleWeaponTip(bool val)
        {
            this.weaponSwapTip.SetActive(val);
            ToggleWeaponTipUI?.Invoke();
        }
    }
}
