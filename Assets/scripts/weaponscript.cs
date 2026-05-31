using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class weaponscript : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] LayerMask layerMask;

    [SerializeField] GameObject hitfx;

    [SerializeField] ParticleSystem muzzle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootSound;

    public void fireaction(weaponSO weapon)
    {
            if (Physics.Raycast(Camera.main.transform.position,
        Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask , QueryTriggerInteraction.Ignore))
            { muzzle.Play();
                Instantiate(hitfx, hit.point ,Random.rotation);
                audioSource.PlayOneShot(shootSound);


                Debug.Log(hit.transform.gameObject.name);
                enemyhealth em = hit.transform.GetComponent<enemyhealth>();
                if (em)
                {
                    em.takedamage(weapon.damage);
                }
            }

        }
    }

