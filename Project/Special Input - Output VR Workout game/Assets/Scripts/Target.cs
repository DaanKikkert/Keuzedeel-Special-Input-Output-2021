using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public bool isFirst = false;
    public bool firstTargetSpawn = false;
    [SerializeField]private float lifeTime;
    public float timeAlive;
    float startTime;
    PlayerManager playerManager;
    TargetSpawner spawner;
    [SerializeField] Material correctTargetMat;
    AudioSource audioSource;
    [SerializeField] AudioClip WrongHitSound;
    [SerializeField] AudioClip CorrectHitSound;
    public GameObject tutorialText;
    // Start is called before the first frame update
    void Start()
    {        
        spawner = GameObject.FindGameObjectWithTag("TargetSpawner").GetComponent<TargetSpawner>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();        
        startTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        lifeTime = spawner.targetLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive = Time.time - startTime;
        if (isFirst == true && firstTargetSpawn == false)
        {
            lifeTime -= Time.deltaTime;
        }
        if(lifeTime <= 0)
        {
            WrongHit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isFirst == true)
        {
            CorrectHit();
        }
        else if(isFirst != true)
        {
            WrongHit();
        }

        if (firstTargetSpawn == true)
        {
            tutorialText = GameObject.FindGameObjectWithTag("Tutorial");
            tutorialText.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        
    }

    public void CorrectHit()
    {
        AudioSource.PlayClipAtPoint(CorrectHitSound, this.gameObject.transform.position);
        spawner.SpawnTarget();
        playerManager.scoreUp();
        Destroy(this.gameObject);        
    }

    public void WrongHit()
    {
        AudioSource.PlayClipAtPoint(WrongHitSound, this.gameObject.transform.position);
        spawner.SpawnTarget();        
        Destroy(this.gameObject);
        playerManager.TakeDamage();
        
    } 

    public void SetFirst()
    {
        GetComponent<Renderer>().material = correctTargetMat;
        isFirst = true;
    }        
}
