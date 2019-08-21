using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecondCharacterScript : MonoBehaviour
{
    int health = 16;

    public Transform tntSpawner;
    public float shot_delay = 2f;
    public GameObject bullet_object;
    private float shot_cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= shot_cooldown && Input.GetKey(KeyCode.K))
        {
            Shoot();
        }

        void Shoot()
        {
            Instantiate(bullet_object, tntSpawner.position, transform.rotation);
            shot_cooldown = Time.time + shot_delay;
        }
    }
}
