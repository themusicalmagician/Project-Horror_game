using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<ItemGenerator> lootlist = new List<ItemGenerator>();

    ItemGenerator GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<ItemGenerator> possibleItems = new List<ItemGenerator>();
        foreach(ItemGenerator item in lootlist)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            ItemGenerator droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No Item Dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        ItemGenerator droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            //float dropForce = 30f;
            //Vector2 dropDirection = Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
}
