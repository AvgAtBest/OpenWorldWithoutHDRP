using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;

public class Weapon : MonoBehaviour
{
    [BoxGroup("Shot Origin")] public Transform shotOrigin;
    [BoxGroup("Int Stats")] public int damage = 15, maxReserveAmmoCap = 1000, maxClip = 100, currentAmmo, currentReserve;
    [BoxGroup("Float Stats")] public float spread = 2f, range = 100f, fireDelay = 0.15f, recoil = 1f, maxTimerWaitROF = 1.2f, reloadDelay = 1.5f;
    [BoxGroup("GameObject")] public GameObject bulletPrefab;
    [HideInInspector] public bool canShoot = false;

    private float shootTimer = 0f;
    private bool isReloading = false;

    private void Start()
    {
        currentReserve = maxReserveAmmoCap;
        currentAmmo = maxClip;
    }
    private void Update()
    {
        shootTimer += Time.deltaTime;
        //ROF
        if(shootTimer >= fireDelay & !isReloading)
        {
            canShoot = true;
            
        }
        if(currentAmmo < maxClip)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
        if (isReloading)
        {
            canShoot = false;
        }

    }
    public void Reload()
    {
        if (!isReloading)
        {

            StartCoroutine(ReloadSequence(reloadDelay));
        }

    }
    public void Shoot()
    {
        currentAmmo--;
        if (currentAmmo == 0)
        {
            Reload();
        }
        //Resets timer and canShoot to false
        shootTimer = 0;
        canShoot = false;

        Camera attachedCamera = Camera.main;

        Transform camTransform = attachedCamera.transform;

        Vector3 bulletOrigin = camTransform.position;

        Quaternion bulletRotation = camTransform.rotation;

        Vector3 lineOrigin = shotOrigin.position;

        Vector3 direction = camTransform.forward;

        GameObject clone = Instantiate(bulletPrefab, bulletOrigin, bulletRotation);
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, direction);

    }
    public IEnumerator ReloadSequence(float delay)
    {
        isReloading = true;
        yield return new WaitForSeconds(delay);
        if (currentReserve > 0)
        {
            if (currentReserve >= maxClip)
            {
                currentReserve -= maxClip - currentAmmo;
                currentAmmo = maxClip;
            }
            if (currentAmmo < maxClip)
            {
                int tempMag = currentReserve;
                currentAmmo = tempMag;
                currentReserve -= tempMag;
            }
        }
        isReloading = false;
    }
}
