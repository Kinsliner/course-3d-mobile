using UnityEngine;

public abstract class WeaponTrigger : MonoBehaviour
{
    protected Weapon weapon;

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public abstract bool CanFire();
}
