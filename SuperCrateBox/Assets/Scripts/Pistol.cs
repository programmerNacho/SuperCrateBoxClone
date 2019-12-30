using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField]
    private Bullet bulletPrefab;

    public override void ButtonHold(int directionX)
    {

    }

    public override void ButtonPressed(int directionX)
    {
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.Initialize(directionX);
    }

    public override void ButtonUp(int directionX)
    {

    }
}
