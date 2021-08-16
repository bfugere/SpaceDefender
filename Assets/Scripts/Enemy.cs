using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Data")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;

    [Header("Projectile Data")]
    float shotCounter;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3.0f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip projectileSFX;
    [SerializeField] [Range(0, 1)] float projectileVolume = 0.1f;

    [Header("Death Data")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyProjectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
            return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        FindObjectOfType<GameManager>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
    }
}
