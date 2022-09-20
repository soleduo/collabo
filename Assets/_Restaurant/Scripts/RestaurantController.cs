using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantController : MonoBehaviour
{
    public Table[] tables;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeOrder()
    {

    }

    public void DeliverOrder()
    {

    }

    public void TakeFood()
    {

    }

    public void DeliverFood()
    {

    }

    public Table GetEmptyTable()
    {
        Table _temp = null;

        foreach(Table table in tables)
        {
            if (table.GetOccupancy())
            {
                _temp = table;
                break;
            }
        }

        return _temp;
    }
}
