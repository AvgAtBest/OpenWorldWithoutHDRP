using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using NaughtyAttributes;

[RequireComponent(typeof(Player))]
public class Shooting : MonoBehaviour
{

    private Player player;
    private CameraLook cameraLook;
    [BoxGroup("Weapon")] public Weapon currentWeapon;
    [BoxGroup("Weapon")] public List<Weapon> weapons = new List<Weapon>();
    [BoxGroup("Weapon")] public int currentWeaponIndex = 0;
    private void Awake()
    {
        player = GetComponent<Player>();
        cameraLook = GetComponent<CameraLook>();
    }
    private void Start()
    {
        //gets all weapons attached to player
        weapons = GetComponentsInChildren<Weapon>().ToList();
        //select first one
        SelectWeapon(0);

    }
    private void Update()
    {
        if (currentWeapon)
        {
            bool fire1 = Input.GetButton("Fire1");
            if (fire1)
            {
                //check if weapon can shoot
                if (currentWeapon.canShoot)
                {
                    //shoot
                    currentWeapon.Shoot();
                    //Apply weapon recoil
                    Vector3 euler = Vector3.up * 2f;
                    //Randomise the pitch
                    euler.x = Random.Range(-1f, 1f);
                    //Apply offset to camera
                    cameraLook.SetTargetOffset(euler * currentWeapon.recoil);
                }
            }
        }
    }
    void SelectWeapon(int index)
    {
        // Check if index is within bounds
        if(index >= 0 && index < weapons.Count)
        {
            //disable all the weapons
            DisableAllWeapons();

            //select current weapon
            currentWeapon = weapons[index];
            //enable current weapon
            currentWeapon.gameObject.SetActive(true);
            //update current weapon index
            currentWeaponIndex = index;

        }
    }
    void DisableAllWeapons()
    {
        foreach(var item in weapons)
        {
            item.gameObject.SetActive(false);
        }
    }
}
