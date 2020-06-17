using UnityEngine;
using UnityEditor;

public class HousingBuilding : Building
{
    public int _spawnInterval;
    public int _workerCapacity;
    public int _initialWorkerCount;
    public GameObject _workerPrefab;

    private float _spawnTimer;
    public void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            if (_workers.Count < _workerCapacity)

            {
                spawnWorker();
            }
            _spawnTimer = 0;
        }
    }

    private void spawnWorker()
    {
        GameObject instance = Instantiate(_workerPrefab, transform.position, transform.rotation);
        // set parent tile
        Worker newWorker = instance.GetComponent<Worker>();
        _workers.Add(newWorker);
    }

    protected override void Start()
    {
        base.Start();

        // spawn initial workers
        for (int i = 0; i < _initialWorkerCount; i++)
        {
            spawnWorker();
        }
    }
    public override void Inintilize(Tile parentTile)
    {
        base.Inintilize(parentTile);
    }
}