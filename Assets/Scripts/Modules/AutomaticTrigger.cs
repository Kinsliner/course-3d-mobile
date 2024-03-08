using UnityEngine;

public class AutomaticTrigger : WeaponTrigger
{
    public float fireRate = 0.1f;

    private float currentFireRate;

    public override bool CanFire()
    {
        return currentFireRate <= 0f;
    }

    private void Update()
    {
        if (weapon == null)
            return;

        // if fire rate is greater than 0, decrease it
        if (currentFireRate > 0f)
            currentFireRate -= Time.deltaTime;
        else
            currentFireRate = fireRate;

    }
}
