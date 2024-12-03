using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health =50;
    [SerializeField] int score= 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer =FindObjectOfType<AudioPlayer>();
        scoreKeeper =FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damageDealer = other.GetComponent<Damage>();

        if(damageDealer != null){

            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCam();
            //thong bao damage 
            damageDealer.Hit();

            
        }
    }

    public int GetHealth(){
        return health;
    }

    void TakeDamage(int damage){
        health -= damage;
        if(health<=0){
            Die();
        }
    }
    
    void Die(){
        if(!isPlayer){
            scoreKeeper.ModifyScore(score);
        }else{
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if(hitEffect != null )
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCam(){
        if(cameraShake != null && applyCameraShake) {
            cameraShake.Play();
        }
    }
}
