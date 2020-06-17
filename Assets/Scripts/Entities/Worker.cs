using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    #region Manager References
    JobManager _jobManager; //Reference to the JobManager
    GameManager _gameManager;//Reference to the GameManager
    #endregion

    public float _age; // The age of this worker
    public float _happiness; // The happiness of this worker
    private float lifeCycleStep;
    private float resCycleStep;
    public bool _hasJob;
    public bool _hasFish;
    public bool _hasClothes;
    public bool _hasSchnapps;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _jobManager = GameObject.Find("JobManager").GetComponent<JobManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeCycleStep += Time.deltaTime;
        resCycleStep += Time.deltaTime;

        if(lifeCycleStep >= 15){
            Age();
            lifeCycleStep = 0;
        }
        if(lifeCycleStep >= 60){
            consumeRes();
            resCycleStep = 0;
        }
        happinessUpdate();
    }


    private void Age()
    {
        //TODO: Implement a life cycle, where a Worker ages by 1 year every 15 real seconds.
        //When becoming of age, the worker enters the job market, and leaves it when retiring.
        //Eventually, the worker dies and leaves an empty space in his home. His Job occupation is also freed up.

            _age++;
            if (_age > 14f && _age <= 64f)
            {
                BecomeOfAge();
            }

            if (_age > 64f && _age <= 100f)
            {
                Retire();
            }

            if (_age > 100f)
            {
                Die();
            }
    }


    public void BecomeOfAge()
    {
        _jobManager.RegisterWorker(this);
    }

    private void Retire()
    {
        _jobManager.RemoveWorker(this);
    }

    private void Die()
    {
        Destroy(this.gameObject, 1f);
    }

    private void consumeRes() {
        if(_gameManager.HasResourceInWarehouse(GameManager.ResourceTypes.Fish)){
            _gameManager.removeResourceFromWarehouse(GameManager.ResourceTypes.Fish,1);
            _hasFish = true;
        }
        else{
            _hasFish = false;
        }
        if (_gameManager.HasResourceInWarehouse(GameManager.ResourceTypes.Clothes)){
            _gameManager.removeResourceFromWarehouse(GameManager.ResourceTypes.Clothes,1);
            _hasClothes = true;
        }
        else{
            _hasClothes = false;
        }

        if (_gameManager.HasResourceInWarehouse(GameManager.ResourceTypes.Schnapps)){
            _gameManager.removeResourceFromWarehouse(GameManager.ResourceTypes.Schnapps,1);
            _hasSchnapps = true;
        }
        else{
            _hasSchnapps = false;
        }
    }

    private void happinessUpdate() {
        _happiness = 0;
        if(_hasJob || _age <= 14f){
            _happiness += 0.5f;
        }
        if(_hasFish){
            _happiness += 0.2f;
        }
        if(_hasClothes){
            _happiness += 0.2f;
        }
        if(_hasSchnapps){
            _happiness += 0.1f;
        }
    }
}