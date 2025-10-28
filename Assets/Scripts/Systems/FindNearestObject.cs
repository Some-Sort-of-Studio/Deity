using UnityEngine;

public static class FindNearestObject
{
    public static T FindNearestObjectByType<T>(Vector3 position, T[] objectsInScene)
    {
        T nearestObject = default(T);
        float nearestDistance = Mathf.Infinity;

        foreach(T obj in objectsInScene){
            if (Vector3.Distance(position, obj.transform.position) < nearestDistance)
            {
                nearestObject = obj;
            }
        }

        return nearestObject;
    }
}
