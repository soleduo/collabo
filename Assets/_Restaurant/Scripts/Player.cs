using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }

    public FoodSO foodOnHand = null;
    public List<FoodOrder> orders = new List<FoodOrder>();


    public event VoidEvent OnPlayerArrived;


    private void Start()
    {
        if(instance == null)
          instance = this;
    }

    public IEnumerator MoveTo(Vector3 targetPos, Table t = null)
    {
        Vector2 dir = (targetPos - transform.position).normalized;
        Vector3 moveVector = ((Vector3.up * dir.y) + (Vector3.right * dir.x));


        while ((targetPos - transform.position).sqrMagnitude > 0.05f) {
            transform.position += moveVector * 3f * Time.deltaTime;
            GameBoard.Instance.GetNextGrid(transform);
            yield return null;
        }

        if(t != null)
            t.Interact();
    }

    public void AddOrder(FoodOrder order)
    {
        if (foodOnHand != null)
        {
            return;
        }

        orders.Add(order);
    }

    public void DumpOrder(Kitchen target)
    {
        foreach(FoodOrder order in orders)
        {

        }
    }
}

public class FoodOrder
{
    public int foodId;
    public Customer owner;

    public FoodOrder(Customer c, int foodId)
    {
        owner = c;
        this.foodId = foodId;
    }

    public FoodSO GetFood()
    {
        return ScriptableItemManager.Instance.foodItems.GetItemById(foodId);
    }
}
