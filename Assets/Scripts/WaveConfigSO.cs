using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;
using static UnityEngine.UIElements.UxmlAttributeDescription;


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 1f;
    [SerializeField] float minSpawnTime = 0.2f;
    

    //to return first waypoint
    public Transform GetStartingwaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    /// <summary>
    /// Okay, best I can tell, this uses the heirarchy to do our work for us.
    /// The heirarchy knows that our scriptable object that this script is attached to, has children in the heirarchy(the waypoints we set up earlier)
    /// If we need to find out where these waypoints are, presumably so that we can use thier transforms to move our enemies, then we need to return the details.
    ///As the serialize fields above are defaulted to private access only, this method allows us to return them to an external Game Object.
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetWaypoints() //to return all waypoints in the path
    {
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab) //loops through all children in the pathPrefab
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) 
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() 
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
