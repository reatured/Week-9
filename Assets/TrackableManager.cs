using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class TrackableManager : MonoBehaviour
{

    private bool bTarget1, bTarget2;
    private Vector3 vT1Pos, vT2Pos;

    private LineRenderer line;

    private float distance;
    public GameObject explosion;
    public float explosionScale;


    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.widthMultiplier = .1f;
        line.positionCount = 2;
        line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        line.startColor = Color.blue;
        line.endColor = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> allTrackables = sm.GetActiveTrackableBehaviours();

        foreach(TrackableBehaviour tb in allTrackables)
        {
            //Debug.Log("tracking >>" + tb.Trackable.Name);

            if(tb.TrackableName == "Dog")
            {

                if(tb.CurrentStatus == TrackableBehaviour.Status.TRACKED)
                {
                    bTarget1 = true;
                    vT1Pos = tb.transform.position;

                }
                else
                {
                    bTarget1 = false;
                }
            }

            if (tb.TrackableName == "SodaCan")
            {

                if (tb.CurrentStatus == TrackableBehaviour.Status.TRACKED)
                {
                    bTarget2 = true;
                    vT2Pos = tb.transform.position;

                }
                else
                {
                    bTarget2 = false;
                }
            }
        }

        if (bTarget1 == true && bTarget2 == true)
        {

            distance = Vector3.Distance(vT1Pos, vT2Pos);

            //Debug.Log(distance);

            //Debug.Log("tracking both objects");
            line.enabled = true;
            var points = new Vector3[2];
            points[0] = vT1Pos;
            points[1] = vT2Pos;
            line.SetPositions(points);


        }
        else
        {
            line.enabled = false;
        }

        


    }
}
