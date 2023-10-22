using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;



public abstract class Item : MonoBehaviour
{
    enum itemType
    {
        Destroyable,
        Consumable,
        KeyItem,
        Power
    }

    [Header("Item Information")]
    [SerializeField] string hoverText;
    [SerializeField] itemType Type;
    [SerializeField] string itemName;
    public int itemQuantity;
    public bool shouldReduceQuantity;

    public GameObject hoverTextUI;

    private Transform startingPos;

    private void Start()
    {
        startingPos = transform;
    }

    private void Update()
    {
       /* float interpolationRatio = (Time.time - startTime) * speed;

        Vector3 interpolatedPosition = Vector3.Lerp(startingPos.position, Vector3.up, interpolationRatio);
        transform.position = interpolatedPosition;
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)*/
    }
    public abstract void Useitem();

    private void OnTriggerEnter(Collider collision)//Shows The UI that says "Press E to interact
    {
        collision.gameObject?.GetComponent<InteractionSystem>();
        hoverTextUI?.SetActive(true);
    }

    private void OnTriggerExit(Collider collision) //Hides The UI that says "Press E to interact
    {
        collision.gameObject?.GetComponent<InteractionSystem>();
        hoverTextUI?.SetActive(false);
    }

    private void OnTriggerStay(Collider collision)
    {
        if(Type == itemType.Consumable ||  Type == itemType.KeyItem || Type == itemType.Power)
        {
            var player = collision.gameObject?.GetComponent<InteractionSystem>();
            if(player != null && player.playerIsInteracting)
            {
                if(player.Items.Count < 6)
                {
                    bool alreadyAdded = false;
                    foreach(GameObject obj in player.Items)
                    {
                        var reference = obj.GetComponent<Item>();
                       if (itemName == reference.itemName)
                        {
                            reference.itemQuantity += itemQuantity;
                            Debug.Log("Increased the quantity of the held item, we now have: " + reference.itemQuantity);
                            alreadyAdded = true;
                            break;
                        }
                    }
                    Destroy(hoverTextUI);
                    gameObject.GetComponent<BoxCollider>().enabled = false;

                    gameObject.transform.SetParent(player.leftAttachPoint);
                    gameObject.transform.position = player.leftAttachPoint.position;
                    gameObject.transform.rotation = player.transform.rotation;

                    if (!alreadyAdded)
                    {
                        player.Items.Add(gameObject);
                    }
                    this.gameObject.SetActive(false);
                    Debug.Log("Added an item the player's inventory");
                }
            }
        }
        else if (Type == itemType.Destroyable)
        {
            //If player attacks do something 
        }

        Quaternion rotation = Quaternion.LookRotation(hoverTextUI.transform.position, collision.transform.position);
        hoverTextUI.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, rotation.z, 0);
    }
}
