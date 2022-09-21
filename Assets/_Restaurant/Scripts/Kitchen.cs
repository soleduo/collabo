using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public Queue<FoodSO> foodToCook;
    public GameObject foodPrefab;


    public event VoidEvent OnOrderAdded;

    public IEnumerator CookFood(FoodSO food)
    {
        yield return new WaitForSeconds(food.cookDuration);


    }

    public void AddFoodToCook(FoodOrder order)
    {
        //foodToCook.Enqueue();
    }
}
