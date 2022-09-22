using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Table : MonoBehaviour, IPointerClickHandler
{
    private bool hasFood = false;
    private bool isDirty = false;
    private Customer customer = null;
    private GameObject customerPrefab;

    private float defaultCustomerTimer = 30f;

    private Placeholder playerPlaceholder;
    private Placeholder customerPlaceholder;
    private Placeholder foodPlaceholder;

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
        List<Placeholder> ph = GetComponentsInChildren<Placeholder>().ToList();

        playerPlaceholder = ph.Find((p) => p.acceptedType == EPlaceholderType.PLAYER);
        customerPlaceholder = ph.Find((p) => p.acceptedType == EPlaceholderType.CUSTOMER);
        foodPlaceholder = ph.Find((p) => p.acceptedType == EPlaceholderType.FOOD);
    }

    // Update is called once per frame
    void Update()
    {
        if (customerTimer <= 0)
        {
            if (customer == null)
                AddCustomer(ScriptableItemManager.Instance.customerItems.GetItemById(0));

            customerTimer = defaultCustomerTimer;
        }

        customerTimer -= Time.deltaTime;

        if (customer != null)
            customer.Update();
    }

    public void AddCustomer(CustomerSO c)
    {
        customer = new Customer(this, c);

        if (customerPrefab == null)
        {
            customerPrefab = Instantiate(c.prefab);
            customerPrefab.transform.position = customerPlaceholder.transform.position;
            GameBoard.Instance.GetNextGrid(customerPrefab.transform);
        }

        customerPrefab.GetComponentInChildren<SpriteRenderer>().sprite = c.icon;
        customerPrefab.SetActive(true);

        OnCustomerAdded?.Invoke(customer);
    }

    public void RemoveCustomer()
    {
        customer = null;
        customerPrefab.SetActive(false);

        isDirty = true;
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
        StartCoroutine(Player.Instance.MoveTo(playerPlaceholder.transform.position, this));
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