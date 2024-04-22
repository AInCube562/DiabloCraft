using UnityEngine;
using System;

[Serializable]public class Drop
{
    [SerializeField] private GameObject item;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;
    [SerializeField] private float speed = 5;

    public void SpawnItemObject(Vector2 position)
    {
        GameObject i = UnityEngine.Object.Instantiate(item);
        i.transform.position = new Vector3(position.x, position.y, item.transform.position.z);
        i.GetComponent<ItemGameObject>().amount = UnityEngine.Random.Range(minAmount, maxAmount);
        i.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * speed,
            ForceMode2D.Impulse);
    }

    public void SpawnItemObject(GameObject itemGameObject, Vector2 position, int amount, Vector2 direction)
    {
        GameObject i = UnityEngine.Object.Instantiate(itemGameObject);
        i.transform.position = new Vector3(position.x, position.y, itemGameObject.transform.position.z);
        i.GetComponent<ItemGameObject>().amount = amount;
        i.GetComponent<Rigidbody2D>().AddForce(direction * speed,
            ForceMode2D.Impulse);
    }
}
