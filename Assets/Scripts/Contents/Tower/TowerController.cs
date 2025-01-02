using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private TowerGround ownerGround;


    public void SetCreateInfo(TowerGround owner)
    {
        ownerGround = owner;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
