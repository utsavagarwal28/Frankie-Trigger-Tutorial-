using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{

    enum State { Idle, Run, Warzone }

    [Header("Elements")]
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    private State state;
    private Warzone currentWarzone;

    [Header("Spline Settings")]
    [SerializeField] private float warzoneTimmer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartRunning();

        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                break;

            case State.Run:
                Move();
                break;

            case State.Warzone:
                ManageWarzoneState();
                break;
        }
    }

    private void StartRunning()
    {
        state = State.Run;
        playerAnimator.PlayRunAnimation();
    }

    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    public void EnteredWarzoneCallback(Warzone warzone)
    {
        if (currentWarzone != null)
            return;

        state = State.Warzone;
        currentWarzone = warzone;

        warzoneTimmer = 0;

        Debug.Log("Entered Warzone");
    }

    private void ManageWarzoneState()
    {
        warzoneTimmer += Time.deltaTime;

        float splinePercent = warzoneTimmer / 2;
        transform.position = currentWarzone.GetPlayerSpline().EvaluatePosition(splinePercent);
    }

}
