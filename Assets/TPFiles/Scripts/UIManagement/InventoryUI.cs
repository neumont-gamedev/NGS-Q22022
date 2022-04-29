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
        InventorySlot s;

        // checks the inventorySlots for whether or not they have fossils
        for(int i = 0; i < inventorySlots.Length - 1; i++)
        {
            s = inventorySlots[i];
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
            else
            {
                EmptySlot(i);
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

    //calls AddToBackpack from FossilHolder.cs
    public void AddToSlot(Fossil fossil)
    {
        if (fossil == null) return;
        InventorySlot s; // slot to store fossil in

        // check for next open spot
        for(int i = 0; i < inventorySlots.Length - 1; i++)
        {
            s = inventorySlots[i];
            if (s.objectPrefab != null) break;
            else
            {
                // update slot info to match fossil's info

                // if no open spots in first menu, open the second menu for inventory
                //   add fossil to next open spot in that menu
            }
        }
    }

    // make sure fossil info matches the inventory ui
    public void UpdateSlot()
    {

    }
}