using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingGrid
{
    public int orderInLayer;
    private GridBound bounds;

    public GridBound Bounds { get { return bounds; } }

    public ScalingGrid(GridBound bounds, int orderInLayer)
    {
        this.bounds = bounds;
        this.orderInLayer = orderInLayer;
    }

}

public class GridBound
{
    public float min;
    public float max;
    public float MidPoint { get { return ((max - min) * 0.5f) + min; } }
    public float Size { get { return (max - min); } }

    public GridBound(float origin, float size)
    {
        min = origin - size * 0.5f;
        max = origin + size * 0.5f;
    }
}
