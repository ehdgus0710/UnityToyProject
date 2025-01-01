using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjPool : MonoBehaviour
{
    [SerializeField]
    public GameObject m_CubeSplitPrefab;

    //IObjectPool<SplitScript> m_CubeObjPool;

    //private void Awake()
    //{
    //    m_CubeObjPool = new ObjectPool<SplitScript>(CreateCubeSplit, OnGetCubeSplit, OnReleaseCubeSplit, OnDestroyCubeSplit, maxSize: 20);
    //}

    //private SplitScript CreateCubeSplit()
    //{
    //    SplitScript CubeSplit = Instantiate(m_CubeSplitPrefab).GetComponent<SplitScript>();
    //    CubeSplit.SetManagedPool(m_CubeObjPool);
    //    return CubeSplit;
    //}
    //private void OnGetCubeSplit(SplitScript CubeSplit)
    //{
    //    CubeSplit.gameObject.SetActive(true);
    //}

    //private void OnReleaseCubeSplit(SplitScript CubeSplit)
    //{
    //    CubeSplit.gameObject.SetActive(false);
    //}

    //private void OnDestroyCubeSplit(SplitScript CubeSplit)
    //{
    //    Destroy(CubeSplit.gameObject);
    //}

    //public IObjectPool<SplitScript> GetObjectPool()
    //{
    //    return m_CubeObjPool;
    //}
}
