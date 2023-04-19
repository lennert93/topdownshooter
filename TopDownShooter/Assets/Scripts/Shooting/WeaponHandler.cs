using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    private List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        addWeapon(currentWeapon);
        setCurrentWeapon(0);
    }
    void Update()
    {
        if (currentWeapon.isAutomatic || Input.GetMouseButton(0))
        {
            currentWeapon.Shoot();
        }
    }


    public Weapon getCurrentWeapon()
    {
        return currentWeapon;
    }
    public void setCurrentWeapon(int weaponIndex)
    {
        currentWeapon = weapons[weaponIndex];
    }
    public void addWeapon(Weapon weapon)
    {
        Weapon w = Instantiate(weapon);
        w.transform.SetParent(transform);
        w.transform.SetPositionAndRotation(transform.position, transform.rotation);
        weapons.Add(w);
    }
    public void removeWeapon(Weapon weapon) 
    {
        Destroy(weapon);
        weapons.Remove(weapon);
    }
}
