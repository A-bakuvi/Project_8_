using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SuperPowerSpawnPoints : MonoBehaviour
{
    [SerializeField] GameObject[] _superPowers;
    [SerializeField] GameObject player;
    [SerializeField] GameObject player1;
    [SerializeField] List<Vector2> _superPowerSpawnPositions;
    private List<Vector2> removedPositions;
    private List<Vector2> remainedPositions;

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
        remainedPositions = new List<Vector2>();
        StartCoroutine(SpawnSuperPowers());
        
    }



    IEnumerator SpawnSuperPowers()
    {
        if (player.gameObject.activeInHierarchy && player1.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(10);
            if (_superPowerSpawnPositions.Count == 0)
            {
                _superPowerSpawnPositions = new List<Vector2>(removedPositions.Except(remainedPositions));
                removedPositions.Clear();
                remainedPositions.Clear();
            }

            _randomSuperPower = Random.Range(0, _superPowers.Length);
            _randomSpawnPosition = Random.Range(0, _superPowerSpawnPositions.Count);
            _pos = _superPowerSpawnPositions[_randomSpawnPosition];

            if (_superPowerSpawnPositions.Count <= 5)
            {
                remainedPositions.Add(_pos);
            }

            if (pc1.number < 5 || pc2.number1 < 5)
            {
                if (pc1.number < 5 && pc2.number1 < 5)
                {
                    pc1.number += 1;
                    pc2.number1 += 1;
                }
                else if (pc1.number < 5)
                {
                    pc1.number += 1;
                }
                else if (pc2.number1 < 5)
                {
                    pc2.number1 += 1;
                }

                Instantiate(_superPowers[_randomSuperPower], _pos, Quaternion.identity);
                //List<Vector2> list = new List<Vector2>(_superPowerSpawnPositions);

                // Remove the specific item
                _superPowerSpawnPositions.Remove(_pos);  // Removes the first occurrence of 3
                removedPositions.Add(_pos);

                // Convert back to an array if needed
                //_superPowerSpawnPositions = list.ToArray();

            }
            StartCoroutine(SpawnSuperPowers());
        }

    }
}
