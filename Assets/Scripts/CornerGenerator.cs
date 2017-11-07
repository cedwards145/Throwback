using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerGenerator : MonoBehaviour
{
    public int sections = 10;
    private PolygonCollider2D polygon;

    // Use this for initialization
    void Start()
    {
        polygon = GetComponent<PolygonCollider2D>();

        Vector2[] points = new Vector2[sections + 2];

        for (int x = 0; x <= sections; x++)
        {
            float xCoord = (1.0f / sections) * x;
            float yCoord = GetYCoordOnUnitCircle(xCoord);

            points[x] = new Vector2(xCoord - 0.5f, yCoord - 0.5f);
        }

        points[sections + 1] = new Vector2(0.5f, 0.5f);

        polygon.points = points;
    }

    private float GetYCoordOnUnitCircle(float x)
    {
        float sqr = 1 - Mathf.Pow(x, 2);

        if (sqr == 0)
        {
            return sqr;
        }
        else
        {
            return Mathf.Sqrt(sqr);
        }
    }
}