using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    enum State { Idle, Run }

    [Header("Elements")]
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    private State state;


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

}
