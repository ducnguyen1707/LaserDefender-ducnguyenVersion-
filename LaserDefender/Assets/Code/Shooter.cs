using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]   
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRateVar =0f;
    [SerializeField] float minFiringRate = 0.1f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake(){
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(useAI){
            isFiring =true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire(){
        if(isFiring && firingCoroutine == null){
            firingCoroutine=  StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine !=null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously(){
        while(true){
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb =instance.GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timetoNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVar,
                                                                    baseFiringRate + firingRateVar);
            timetoNextProjectile =Mathf.Clamp(timetoNextProjectile, minFiringRate, float .MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(baseFiringRate); 


        }
    }
}
