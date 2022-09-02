using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CupParentMovement : MonoBehaviour
{
    float directionX;
    float mousePositionX;
    public float swerveLimit;
    public float swerveValue;

    public float speed;
    void Update()
    {
        Vector3 direc = transform.forward * (Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = transform.localPosition;
            directionX = position.x;
            mousePositionX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }

        if (Input.GetMouseButton(0))
        {
            float newmousePositionX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            float distanceX = newmousePositionX - mousePositionX;

            float positionX = directionX + (distanceX * swerveValue);
            positionX = Mathf.Clamp(positionX, -swerveLimit, swerveLimit);

            Vector3 position = transform.localPosition;
            position.x = positionX;
            transform.localPosition = position;
        }

        transform.Translate(direc);
    }
}
