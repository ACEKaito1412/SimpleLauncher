using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils{

    public GameObject ObjectReference { get; private set; }
    public bool createBoxCast(Transform transform, Vector2 castSize, float offSetX, float offSetY , LayerMask layer)
    {
        // Define the BoxCast parameters
        Vector2 castCenter = new Vector2(transform.position.x + offSetX, transform.position.y + offSetY);

        float castAngle = 0; // Angle of the BoxCast
        Vector2 castDirection = Vector2.up; // Direction of the BoxCast
        float castDistance = 0.1f; // Distance of the BoxCast

        // Perform the BoxCast
        RaycastHit2D raycast = Physics2D.BoxCast(castCenter, castSize, castAngle, castDirection, castDistance, layer);

        // Draw the BoxCast for visualization
        DrawBoxCast(castCenter, castSize, castAngle, castDirection, castDistance, raycast);

        if (raycast.collider != null)
        {

            // Get the hit point and calculate the direction from the BoxCast center
            Vector2 hitPoint = raycast.point;
            Vector2 directionToHit = hitPoint - (Vector2)castCenter;

            ObjectReference = raycast.collider.gameObject;
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DrawBoxCast(Vector2 center, Vector2 size, float angle, Vector2 direction, float distance, RaycastHit2D hitInfo)
    {
        Vector2 halfSize = size / 2;

        // Calculate the box corners
        Vector2 topLeft = center + new Vector2(-halfSize.x, halfSize.y);
        Vector2 topRight = center + new Vector2(halfSize.x, halfSize.y);
        Vector2 bottomLeft = center + new Vector2(-halfSize.x, -halfSize.y);
        Vector2 bottomRight = center + new Vector2(halfSize.x, -halfSize.y);

        // Draw the edges of the box
        Debug.DrawLine(topLeft, topRight, Color.green);
        Debug.DrawLine(topRight, bottomRight, Color.green);
        Debug.DrawLine(bottomRight, bottomLeft, Color.green);
        Debug.DrawLine(bottomLeft, topLeft, Color.green);

        // Draw the BoxCast direction and distance
        Debug.DrawRay(center, direction * distance, Color.red);

        // Optionally, draw the hit point
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(center, hitInfo.point, Color.blue);
        }
    }
}