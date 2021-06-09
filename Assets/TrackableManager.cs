using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class TrackableManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> allTrackables = sm.GetActiveTrackableBehaviours();

        foreach(TrackableBehaviour tb in allTrackables)
        {
            Debug.Log("tracking >>" + tb.Trackable.Name);
        }
    }
}
