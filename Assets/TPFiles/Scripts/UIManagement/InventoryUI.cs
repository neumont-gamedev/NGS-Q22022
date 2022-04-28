using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject[] inventoryObjects;
    [SerializeField] InventorySlot[] inventorySlots;
    [SerializeField] Sprite emptySprite;
    [SerializeField] int maxCapacityPerMenu = 9;

    static FossilHolder fh;

    // updating inventory to make sure the information is correct for UI
    // run after anything is added to/removed from inventory
    public void UpdateInventory()
    {
        // checks the inventorySlots for whether or not they have fossils or not
        foreach(InventorySlot s in inventorySlots)
        {
            if(s.objectPrefab != null)
            {
                s.button.interactable = true;
                if(s.fossilInfo != null)
                {
                    s.image.sprite = s.fossilInfo.inventorySprite;
                    s.objectPrefab = s.fossilInfo.fossilPrefab;
                }
                else
                {
                    Debug.LogError($"uh oh, no fossil info in {s.name}");
                }
            }
        }
    }

    // add fossil to inventory
    //   if the inventory slots are full, select inventory slot from secondary menu and activate it
    //   else pick the first inventory slot that is open
    //   change inventory slot to match fossil info and activate fossil image

    // OnGrabFossilFromInv()
    //   runs GrabFossil() from FossilHolder.cs
    //   removes fossil (and its info) from inventory slot 

    public void OnGrabFossil(Fossil fossil)
    {
        int fossilIndex = fh.GrabFossil(fossil);
        EmptySlot(fossilIndex);
        //UpdateInventory();
    }

    public void EmptySlot(int slotIndex)
    {
        if (slotIndex < 0)
        {
            Debug.LogError("how dare you give me an invalid index");
            return;
        }

        // disables button from being clicked
        inventorySlots[slotIndex].button.interactable = false;
        inventorySlots[slotIndex].fossilInfo = null;
        inventorySlots[slotIndex].image.sprite = emptySprite;
        inventorySlots[slotIndex].objectPrefab = null;
    }

    // make sure fossil info matches the inventory ui
    public void UpdateSlot()
    {

    }
}