using System;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    PlayerBullet, EnemyBullet, EnemySmall, EnemyMedium, EnemyBig, Explotion
}

[Serializable]
public struct Object
{
    public ObjectType type;
    public GameObject prefab;
    public List<GameObject> list;
    public int size;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Object> objects;

    private static ObjectPool instance;

    public static ObjectPool Instance => instance;

    public GameObject Get(ObjectType type)
    {
        Object obj = objects.Find(item => item.type == type);

        if (obj.Equals(default(Object)))
            throw new Exception("Object not found.");

        foreach (var item in obj.list)
            if (!item.activeSelf)
            {
                item.SetActive(true);
                return item;
            }

        Add(type, 1);
        var aux = obj.list[^1];
        aux.SetActive(true);
        return aux;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        foreach (var obj in objects)
            Add(obj.type, obj.size);
    }

    private void Add(ObjectType type, int amount)
    {
        Object obj = objects.Find(item => item.type == type);

        for (int i = 0; i < amount; i++)
        {
            var temp = Instantiate(obj.prefab, transform);
            temp.SetActive(false);
            obj.list.Add(temp);
        }
    }
}