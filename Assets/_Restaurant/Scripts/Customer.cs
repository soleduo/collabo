using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private float happiness = 30f;
    private int happinessLevel = 3;
    private float decayRate = 3f;
    private CustomerStateMachine stateMachine;
    private FoodOrder order;
    private float eatingDuration;

    public TableViewDebug viewDebug;

    public Table table;
    public bool IsTableDirty { get { return table.IsDirty; } }
    public float EatingDuration { get { return eatingDuration; } }
    public int FoodOrder { get { return FoodOrder; } }



    public Customer(Table table)
    {
        this.table = table;
        viewDebug = table.GetComponent<TableViewDebug>();

        eatingDuration = 10f;

        stateMachine = new CustomerStateMachine(this);
    }

    public void Update()
    {
        stateMachine.Update();
    }

    public void DecayHappiness()
    {
        if (happiness <= 0)
            RemoveHappiness();

        happiness -= decayRate * Time.deltaTime;
    }

    public void AddHappiness()
    {
        if(happinessLevel < 3)
            happinessLevel++;
        happiness = 30f;
    }

    public void RemoveHappiness()
    {
        if (happinessLevel <= 0)
        {
            table.RemoveCustomer();
            return;
        }

        happinessLevel--;
        happiness = 30f;
    }

    public void Interact()
    {
        stateMachine.ActiveState.OnInteract();
    }
}
