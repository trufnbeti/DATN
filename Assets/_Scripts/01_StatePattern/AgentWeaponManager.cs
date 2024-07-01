using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class AgentWeaponManager : MonoBehaviour
    {
        SpriteRenderer spriteRender;

        public bool drawWeaponGizmo = true;
        public Color gizmoColor = new Color(1, 0, 1, 0.3f);

        
        private WeaponsStorage weaponStorage;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickUp;

        private void Awake()
        {
            weaponStorage = new WeaponsStorage();
            spriteRender = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
            
        }

        private void Start()
        {
            WeaponData currentWeapon = GetCurrentWeapon();
            if (currentWeapon == null)
                return;
            SwapWeaponSprite(currentWeapon.weaponSprite);
            if(weaponStorage.WeaponCount > 1)
            {
                OnMultipleWeapons?.Invoke();
            }
        }

        public void ToggleWeaponVisibility(bool val)
        {
            if (val)
            {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }
            spriteRender.enabled = val;
        }

        private void SwapWeaponSprite(Sprite sprite)
        {
            spriteRender.sprite = sprite;
            OnWeaponSwap?.Invoke(sprite);

        }

        public WeaponData GetCurrentWeapon()
        {
            return weaponStorage.GetCurrentWeapon();
        }

        public void SwapWeapon()
        {
            if (weaponStorage.WeaponCount <= 0)
                return;
            SwapWeaponSprite(weaponStorage.SwapWeapon().weaponSprite);
        }

        public void AddWeaponData(WeaponData weaponData)
        {
            if (weaponStorage.AddWeaponData(weaponData)==false)
            {
                return;
            }
            if (weaponStorage.WeaponCount == 2)
                OnMultipleWeapons?.Invoke();
            SwapWeaponSprite(weaponData.weaponSprite);
        }

        public void PickUpWeapon(WeaponData weaponData)
        {
            AddWeaponData(weaponData);
            OnWeaponPickUp?.Invoke();
        }

        public bool CanIUseWeapon(bool isGrounded)
        {
            if (weaponStorage.WeaponCount <=0)
                return false;
            return weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponStorage.GetPlayerWeaponNames();
        }

        

        
    }
}
