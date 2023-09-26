using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        GetComponent<Weapon>().weaponData = weaponData;
        transform.name = weaponData.WeaponName;
        GetComponent<SpriteRenderer>().sprite = weaponData.WeaponSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

