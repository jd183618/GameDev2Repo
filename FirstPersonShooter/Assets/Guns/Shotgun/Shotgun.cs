using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    protected override void PrimaryFire()
    {
        //Check for delay
        if (shoot_delay_timer <= 0)
        {
            if (primary_fire_is_shooting || primary_fire_hold)
            {
                primary_fire_is_shooting = false;
                shoot_delay_timer = gunData.primary_fire_delay;

                for(int i = 0; i < 6; i++)
                {
                    //Set direction of ray
                    Vector3 dir = Quaternion.AngleAxis(Random.Range(-gunData.spread, gunData.spread), Vector3.up) * cam.transform.forward;
                    dir = Quaternion.AngleAxis(Random.Range(-gunData.spread, gunData.spread), Vector3.right) * dir;

                    //Raycast
                    ray = new Ray(cam.transform.position, dir);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, gunData.range))
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.blue, 0.05f);
                    }
                }

                //Subract Ammo
                ammo_in_clip--;
                if (ammo_in_clip <= 0) ammo_in_clip = gunData.ammo_per_clip;

            }
        }
    }
}
