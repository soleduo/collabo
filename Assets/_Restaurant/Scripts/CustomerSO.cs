using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Customer", order = 1)]

public class CustomerSO : ScriptableItem
{
    public GameObject prefab;
    public string displayName;
    [Header("Game Parameters")]
    public float happinessDecayRate = 3f;
    public float eatingDuration = 10f;
    public FoodSO[] possibleFoodToOrder;
}
