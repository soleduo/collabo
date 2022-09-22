using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private static GameBoard instance;
    public static GameBoard Instance { get { return instance; } }

    public List<ScalingGrid> grids = new List<ScalingGrid>();
    private int maxOrderInLayer = 4;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int j = 0;
        float a = 1.75f;
        float origin = -4.5f;
        

        for (int i = maxOrderInLayer; i > 0; i--)
        {
            ScalingGrid grid = new ScalingGrid(new GridBound(origin + a * 0.5f, a), i);

            grids.Add(grid);

            origin += a - j * 0.25f;
            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ScalingGrid GetNextGrid(Transform t)
    {
        ScalingGrid _grid = null;
        for (int i = 0; i < grids.Count; i++)
        {
            float y = t.transform.position.y - grids[i].Bounds.MidPoint;

            if (y > 0)
            {
                continue;
            }

            _grid = grids[i];
            t.GetComponentInChildren<SpriteRenderer>().sortingOrder = _grid.orderInLayer;
            break;
        }

        return _grid;
    }

    private void OnDrawGizmos()
    {
        float screenMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
        float screenMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)).x;

        Gizmos.color = Color.yellow;


        if (grids.Count > 0)
        {
            foreach(ScalingGrid grid in grids)
            {
                Gizmos.DrawLine(new Vector3(screenMin, grid.Bounds.MidPoint), new Vector3(screenMax, grid.Bounds.MidPoint));
                //Gizmos.DrawLine(new Vector3(screenMin, grid.Bounds.max), new Vector3(screenMax, grid.Bounds.max));
            }
        }
    }
}
