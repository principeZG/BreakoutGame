using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration params
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update ()
    {
        var mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minPosX, maxPosX);
        transform.position = paddlePos;



    }
}
