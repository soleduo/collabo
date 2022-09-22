using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableItemManager : MonoBehaviour
{
    private static ScriptableItemManager instance;
    public static ScriptableItemManager Instance { get { return instance; } }

    public FoodContainerSO foodItems;
    public CustomerContainerSO customerItems;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
