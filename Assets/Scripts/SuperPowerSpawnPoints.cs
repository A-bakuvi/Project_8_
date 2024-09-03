using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerSpawnPoints : MonoBehaviour
{
    [SerializeField] GameObject[] _superPowers;
    [SerializeField] List<Vector2> _superPowerSpawnPositions;
    private List<Vector2> removedPositions;

    public Player1controller pc1;
    public Player2Controller pc2;

    int _randomSuperPower;
    int _randomSpawnPosition;
    float _screenX;
    float _screenY;
    Vector2 _pos;
    //bool keepChecking = true; // Brilliant method to keep checking for collisions

    void Start()
    {
        removedPositions = new List<Vector2>();
        StartCoroutine(SpawnSuperPowers());
        
    }



    IEnumerator SpawnSuperPowers()
    {
        if (_superPowerSpawnPositions.Count == 0)
        {
            _superPowerSpawnPositions = removedPositions;
            removedPositions.Clear();
        }

        _randomSuperPower = Random.Range(0, _superPowers.Length);
        _randomSpawnPosition = Random.Range(0, _superPowerSpawnPositions.Count);
        _pos = _superPowerSpawnPositions[_randomSpawnPosition];

        if (pc1.number < 5 || pc2.number1 < 5)
        {
            Instantiate(_superPowers[_randomSuperPower],_pos, Quaternion.identity);
            //List<Vector2> list = new List<Vector2>(_superPowerSpawnPositions);

            // Remove the specific item
            _superPowerSpawnPositions.Remove(_pos);  // Removes the first occurrence of 3
            removedPositions.Add(_pos);

            // Convert back to an array if needed
            //_superPowerSpawnPositions = list.ToArray();

            pc1.number += 1;
            pc2.number1 += 1;

        }

        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnSuperPowers());
    }

}
