﻿using Asteroid.Ammo;
using UnityEngine;

namespace Asteroid.Ship
{
    [RequireComponent(typeof(WeaponAudio))]
    public class WeaponController : MonoBehaviour
    {
        private const float FireRate = .2f;
        private float _fireTimer;

        private WeaponAudio _weaponAudio;
        [SerializeField] private Transform weaponLeft;
        [SerializeField] private Transform weaponRight;

        private void Awake()
        {
            _weaponAudio = GetComponent<WeaponAudio>();

            GameManager.OnGameStarts += WeaponsOn;
            GameManager.OnGameOver += WeaponsOff;
            GameManager.OnGameWin += WeaponsOff;
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (!Input.GetButton("Fire1") || _fireTimer < FireRate)
            {
                return;
            }

            _fireTimer = 0f;
            Fire();
            Play();
        }

        private void Play()
        {
            _weaponAudio.Play();
        }

        private void Fire()
        {
            // left cannon fire
            var missile1 = MissilePool.Instance.Get();
            var missileTransform1 = missile1.transform;
            missileTransform1.rotation = weaponLeft.rotation;
            missileTransform1.position = weaponLeft.position;
            missile1.gameObject.SetActive(true);

            // right cannon fire
            var missile2 = MissilePool.Instance.Get();
            var missileTransform2 = missile2.transform;
            missileTransform2.rotation = weaponRight.rotation;
            missileTransform2.position = weaponRight.position;
            missile2.gameObject.SetActive(true);
        }

        private void WeaponsOn()
        {
            enabled = true;
        }

        private void WeaponsOff()
        {
            enabled = false;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStarts -= WeaponsOn;
            GameManager.OnGameOver -= WeaponsOff;
            GameManager.OnGameWin -= WeaponsOff;
        }
    }
}