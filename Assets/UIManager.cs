using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UpperMenuSection upperMenuSection;

    public UpperMenuSection UpperUISection => upperMenuSection;
}
