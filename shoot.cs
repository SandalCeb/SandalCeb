using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;

    public ParticleSystem efffect_shoot;

    public Camera fpsCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            if (transform.parent.name == "hand")
            { 
                Shoot();
            }
        }
    }

    void Shoot()
    {
        efffect_shoot.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
                

            Target target_script = hit.transform.GetComponent<Target>();
            if (target_script != null)
            {
                target_script.TakeDamage(damage);
            }
        }
    }
}
