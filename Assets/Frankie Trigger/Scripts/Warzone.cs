using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SplineContainer playerSpline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spline GetPlayerSpline()
    {
        return playerSpline.Spline;
    }
}
