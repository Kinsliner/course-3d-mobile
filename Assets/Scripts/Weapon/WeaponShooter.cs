using UnityEngine;

public abstract class WeaponShooter : MonoBehaviour
{
    protected Weapon weapon;

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public abstract void Shoot(GameObject prefab);
}
