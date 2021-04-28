using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSorter : MonoBehaviour
{
    [SerializeField] public List<Target> activeTargets;
    void Start()
    {        
    }
    
    void Update()
    {        
        activeTargets = new List<Target>();
        GameObject[] currentTargets;
        currentTargets = GameObject.FindGameObjectsWithTag("Target");        
        foreach(GameObject i in currentTargets)
        {
            Target ts = i.GetComponent<Target>();
            activeTargets.Add(ts);
        }
        activeTargets.Sort(SortByTime);
        activeTargets[0].SetFirst();
    }

    static int SortByTime(Target t1, Target t2)
    {
        return t2.timeAlive.CompareTo(t1.timeAlive);
    }
}
