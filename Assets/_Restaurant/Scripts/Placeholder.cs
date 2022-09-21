using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public EPlaceholderType acceptedType;
}

public enum EPlaceholderType
{
    PLAYER,
    CUSTOMER,
    FOOD
}
