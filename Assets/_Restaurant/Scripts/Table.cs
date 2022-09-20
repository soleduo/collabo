using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Table : MonoBehaviour, IPointerClickHandler
{
    private bool hasFood = false;
    private bool isDirty = false;
    private Customer customer = null;

    private float defaultCustomerTimer = 30f;
    public float customerTimer = 0f;

    public bool IsDirty { get { return isDirty; } }
    public bool IsOccupied { get { return customer != null; } }
    public bool HasFood { get { return hasFood; } }

    public event CustomerEvent OnCustomerAdded;
    public event VoidEvent OnTableCleaned;
    public event VoidEvent OnFoodDelivered;
    public event VoidEvent OnCustomerLeft;

    // Start is called before the first frame update
    void Start()
    {
        customerTimer = Random.Range(5, 16);
    }

    // Update is called once per frame
    void Update()
    {
        if (customerTimer <= 0)
        {
            if (customer == null)
                AddCustomer(new Customer(this));

            customerTimer = defaultCustomerTimer;
        }

        customerTimer -= Time.deltaTime;

        if (customer != null)
            customer.Update();
    }

    public void AddCustomer(Customer c)
    {
        customer = c;
        OnCustomerAdded?.Invoke(c);
    }

    public void RemoveCustomer()
    {
        customer = null;
        OnCustomerLeft?.Invoke();
    }

    public bool GetOccupancy()
    {
        return customer == null;
    }

    public void CleanTable()
    {
        isDirty = false;
        OnTableCleaned?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Player.Instance.MoveToTable(this));
    }

    public void Interact()
    {
        if (customer != null)
            customer.Interact();

        if (isDirty)
            CleanTable();
    }
}

public delegate void CustomerEvent(Customer customer);
public delegate void VoidEvent();