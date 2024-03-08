using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public WeaponTrigger trigger;
    public WeaponShooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        if (trigger != null)
        {
            trigger.SetWeapon(this);
        }
        if (shooter != null)
        {
            shooter.SetWeapon(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger != null && shooter != null)
        {
            if (trigger.CanFire())
            {
                shooter.Shoot(bulletPrefab);
            }
        }
    }
}
