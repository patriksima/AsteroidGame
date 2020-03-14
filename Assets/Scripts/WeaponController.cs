﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    [RequireComponent(typeof(WeaponAudio))]
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform weaponLeft;
        [SerializeField] private Transform weaponRight;

        private WeaponAudio _weaponAudio;

        private const float FireRate = .3f;
        private float _fireTimer;

        private void Awake()
        {
            _weaponAudio = GetComponent<WeaponAudio>();
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (Input.GetButton("Fire1") && _fireTimer > FireRate)
            {
                _fireTimer = 0f;
                Fire();
                Play();
            }
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
    }
}