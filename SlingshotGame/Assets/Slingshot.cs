using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    bool isMouseDown;

    public Vector3 currentPosition;
    public float maxLength;

    public float topBoundary;
    public float bottomBoundary;
    public float leftBoundary;
    public float rightBoundary;

    public GameObject ballProjectile;
    Rigidbody2D ball;
    Collider2D ballCollider;

    public float ballPositionOffset;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateBall();
    }

    void CreateBall()
    {
        ball = Instantiate(ballProjectile).GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<Collider2D>();
        ballCollider.enabled = false;

        ball.isKinematic = true;
        ResetStrips();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            
            currentPosition = ClampBoundaryX(currentPosition);
            currentPosition = ClampBoundaryY(currentPosition);

            SetStrips(currentPosition);

            if (ballCollider)
            {
                ballCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }

    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        ball.isKinematic = false;
    }

    void Shoot()
    {
        ball.isKinematic = false;
        Vector3 ballForce = (currentPosition - center.position) * force * -1;
        ball.velocity = ballForce;

        
        ball = null;
        ballCollider = null;
        Invoke("CreateBall", 0.1f);
    }


    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (ball)
        {
            Vector3 dir = position - center.position;
            ball.transform.position = position + dir.normalized * ballPositionOffset;
            ball.transform.up = -dir.normalized;
        }

    }
    
    

    Vector3 ClampBoundaryY(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, topBoundary);
        return vector;
    }
    Vector3 ClampBoundaryX(Vector3 vector)
    {
        vector.x = Mathf.Clamp(vector.x, leftBoundary, rightBoundary);
        return vector;
    }

}
