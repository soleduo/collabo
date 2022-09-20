using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableViewDebug : MonoBehaviour
{
    public Table table;
    public SpriteRenderer image;
    public Color state_Empty = Color.white;
    public Color state_WaitForOrder = Color.blue;
    public Color state_TakingOrder = Color.cyan;
    public Color state_WaitForFood = Color.blue;
    public Color state_Eating = Color.green;
    public Color state_TableDirty = Color.red;

    private void Start()
    {
        table.OnCustomerLeft += () => { image.color = state_TableDirty; };
        table.OnTableCleaned += () => { image.color = state_Empty; };
    }

}
