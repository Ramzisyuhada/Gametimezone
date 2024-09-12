using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WeaponViewModel 
{
    public void Shoot(GameObject turret,Ray ray,GameObject posisition)
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = ray.origin;
            bullet.transform.rotation = Quaternion.LookRotation(ray.direction);
            bullet.SetActive(true); 

           
           


        }
         
    }
}
