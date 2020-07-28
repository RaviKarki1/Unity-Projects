using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public class WeaponStats
    {
        public string name;
        public float fireRate;
        public float ammoCount;

        public WeaponStats(string name, float fireRate, float ammoCount)
        {
            this.name = name;
            this.fireRate = fireRate;
            this.ammoCount = ammoCount;
        }
    }




    WeaponStats weaponDetail;
    // Start is called before the first frame update
    void Start()
    {
        weaponDetail = new WeaponStats("Blaster", .25f, 5);
       // Debug.Log(weaponDetail.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //do sth on shoot
    }
}
