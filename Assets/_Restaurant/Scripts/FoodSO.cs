using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Food", order = 1)]
public class FoodSO : ScriptableItem
{
    public float cookDuration;
    public GameObject prefab;
    public GameObject dirtyPrefab;
}

public class ScriptableItem : ScriptableObject
{
    public int id;
    public Sprite icon;

}
