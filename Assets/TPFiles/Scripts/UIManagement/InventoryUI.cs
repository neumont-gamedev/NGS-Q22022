using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] inventoryObjects;
    public InventorySlot[] inventorySlots;


}

public class InventorySlot
{
    public Image image;
    public GameObject gameObject;
}
