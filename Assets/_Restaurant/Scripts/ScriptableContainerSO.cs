using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableContainerSO<T> : ScriptableObject where T : ScriptableItem
{
    [SerializeField]
    private List<T> objects;

    public T GetItemById(int id)
    {
        T item = objects.Find((a) => a.id == id);
        return item;
    }

    public T GetItemByName(string name)
    {
        T item = objects.Find((a) => a.name.GetHashCode() == name.GetHashCode());

        return item;
    }
}
