using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] targetLocations;
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject firstTargetObject;
    [SerializeField] public List<GameObject> activeTargets;
    public List<GameObject> allTargets;
    public int listResetCount;    
    [SerializeField] List<GameObject> targetObjects;
    public UnityEvent hitEvent;
    public float targetLifeTime;
    [SerializeField] float targetLifeTimeDecay;

    // Start is called before the first frame update
    void Start()
    {
        targetObjects = new List<GameObject>(targetLocations);
        SpawnFirstTarget();
        SpawnTarget();
        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {             
    }

    public void SpawnTarget()
    {        
        int targetIndex = Random.Range(0, targetLocations.Length);
        Debug.Log(targetIndex);
        GameObject[] currentTargets;
        currentTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargets = new List<GameObject>(currentTargets);
        for (int i = 0; i < activeTargets.Count; i++)
        {
            if(activeTargets[i].transform.position == targetLocations[targetIndex].transform.position)
            {
                SpawnTarget();
                Debug.Log("ARGH");
                return;
            }
        }        
        GameObject newTarget = Instantiate(targetObject, targetObjects[targetIndex].gameObject.transform.position, targetObjects[targetIndex].gameObject.transform.rotation);
        targetLifeTime -= targetLifeTimeDecay;
    }

    public void SpawnFirstTarget()
    {        
        int targetIndex = Random.Range(0, targetLocations.Length);
        Debug.Log(targetIndex);
        GameObject[] currentTargets;
        currentTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargets = new List<GameObject>(currentTargets);        
        GameObject newTarget = Instantiate(firstTargetObject, targetObjects[targetIndex].gameObject.transform.position, targetObjects[targetIndex].gameObject.transform.rotation);              
    }      
}
