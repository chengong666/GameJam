using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPontsMgr : SingletonMonoCG<BornPontsMgr>
{
    [SerializeField]    
    Dictionary<string,Transform> BornTransforms = new Dictionary<string, Transform>();
    [SerializeField]
    Transform player;    
    [SerializeField]
    List<Transform> transforms;
    protected override void Awake()
    {
        player = GameObject.Find("Player").transform;
        base.Awake();
        for (int i = 0; i < transform.childCount; i++)
        {
            BornTransforms.Add(transform.GetChild(i).name, transform.GetChild(i));
        }
        foreach (Transform t in BornTransforms.Values)
        {
            transforms.Add(t);
        }
    }
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void SetPlayerPos(string BornPos)
    {
        player.position = new Vector3(BornTransforms[BornPos].position.x, BornTransforms[BornPos].position.y, 0);
    }
}
