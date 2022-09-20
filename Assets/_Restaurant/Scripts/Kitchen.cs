using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public Queue<Food> foodToCook;
    public GameObject foodPrefab;


    public event VoidEvent OnOrderAdded;

    public IEnumerator CookFood(Food food)
    {
        yield return new WaitForSeconds(food.cookDuration);


    }
}
