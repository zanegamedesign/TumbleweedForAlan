using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecondCharacterScript : MonoBehaviour
{
    public GameObject HarrysHealthBar;
    int health = 16;
    public Sprite[] HealthBarImages;

    public Transform tntSpawner;
    public float shot_delay = 2f;
    public float block_delay = 3f;
    public GameObject bullet_object;
    private float shot_cooldown = 0f;
    private float block_cooldown = 0f;

    public GameObject blockPrefab;
    private bool isBlocking = false;
    public int blockDamageReduction = 2;
    public float blockDuration = 2f;
    private float blockDurationCooldown = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= shot_cooldown && Input.GetKey(KeyCode.S))
        {
            Shoot();
        }

        HarrysHealthBar.GetComponent<SpriteRenderer>().sprite = HealthBarImages[health - 1];

        if (isBlocking)
            blockDurationCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.L))
        {
            if (Time.time >= block_cooldown)
            {
                Block(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || (blockDurationCooldown <= 0 && isBlocking))
        {
            Block(false);
        }

    }
    void Shoot()
    {
        Instantiate(bullet_object, tntSpawner.position, tntSpawner.rotation);
        shot_cooldown = Time.time + shot_delay;
    }
    void Block(bool block)
    {
        isBlocking = block;
        if (block == false)
        {
            Debug.Log("Stop blocking");
            block_cooldown = Time.time + block_delay;
            blockPrefab.SetActive(false);
        }
        else
        {
            Debug.Log("Start blocking");
            blockDurationCooldown = blockDuration;
            blockPrefab.SetActive(true);
        }
    }
    public void TakeDamage(int amount)
    {
        if (isBlocking == false)
        {
            health -= amount;
        }
        else
        {
            health -= (amount - blockDamageReduction);
        }
    }


}
