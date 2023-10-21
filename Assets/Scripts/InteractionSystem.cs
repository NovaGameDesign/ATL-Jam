using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    private InputAction interact;
    private InputAction useItem;
    private InputAction scroll;
    [System.NonSerialized] public bool playerIsInteracting;

    [Header("Inventory")]
    public List<GameObject> Items = new List<GameObject>();
    private int activeItem;
    private GameObject outItem;
    public Transform leftAttachPoint;

    private void Awake()
    {
        interact = playerInput.actions["Interact"];
        interact.performed += Interact;
        interact.canceled += Interact;
        useItem = playerInput.actions["Use Item"];
        useItem.performed += UseItem;
        scroll = playerInput.actions["Scroll Items"];
        scroll.performed += scrollQuickItems;
    }

    private void scrollQuickItems(InputAction.CallbackContext context)
    {
        int scrollValue = (int)Mathf.Clamp(scroll.ReadValue<Vector2>().y, -1, 1);
        
        activeItem += scrollValue;
        if(activeItem > Items.Count)
        {
            activeItem = Items.Count-1;
        }
        else if (activeItem < 0)
        {
            activeItem = 0;
        }
        Items[activeItem].SetActive(true);
        //outItem = Instantiate(Items[activeItem]);
        Debug.Log("The current scroll value is: " + activeItem);
    }

    private void UseItem(InputAction.CallbackContext context)
    {
        var currentItem = Items[activeItem].GetComponent<Item>();
        currentItem.Useitem();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerIsInteracting = true;
            
        }
        if (context.canceled)
        {
            playerIsInteracting = false;
        }
    }
}
