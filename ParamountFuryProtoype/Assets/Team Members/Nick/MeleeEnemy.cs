using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float Speed;
    [SerializeField] int AttackDamage;
    [SerializeField] float AttackRange;

    GameObject Player;
    private NickNavMapgroup MapGroup;
    private NickNavMain Main;
    private NickNavNode PlayerNode;
    private Vector3[] pos;

    private bool HavePath;
    private int stepcount;
    private Vector3 waypoint;
    private List<NickNavNode> Path;
    private int pathindex;
    private Vector3 prevplayerpos;

    private bool atPlayer;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MapGroup = FindObjectOfType<NickNavMapgroup>();

        Main = FindObjectOfType<NickNavMain>();
        pos = MapGroup.Getpos();
        atPlayer = false;
        HavePath = false;

        PlayerNode = MapGroup.GetNearestNode(Player.transform.position); // update player node
        UpdatePath(PlayerNode);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (atPlayer)
        {
            Attack();
            atPlayer = false;
        }
        else
        {
            MoveToPlayer();
        }

        prevplayerpos = Player.transform.position;
    }

    void UpdatePath(NickNavNode Goal)
    {
        Path = Main.Findpath(MapGroup.GetNearestNode(transform.position), Goal); // find path to updated goal
        stepcount = 0;

        if (Path.Count != 0)
        {
            HavePath = true;
        }
        else
        {
            Debug.Log("I can't get there from here");
            return;
        }

        pathindex = 0;
        waypoint = pos[Path[pathindex].graphindex]; // get a waypoint 

        return;
    }


    public void MoveToPlayer()
    {
        float step = Speed * Time.deltaTime;

        if (HavePath)
        {
            if (stepcount > 100)
            {
                PlayerNode = MapGroup.GetNearestNode(Player.transform.position); // update player node
                UpdatePath(PlayerNode);
            }


            transform.position = Vector3.MoveTowards(transform.position, waypoint, step);
            stepcount += 1;

            if (waypoint == transform.position) // need to update pathindex
            {
                if (pathindex == Path.Count - 1) //reached player
                {
                    atPlayer = true;
                    HavePath = false;
                }
                else
                {
                    pathindex++;
                    waypoint = pos[Path[pathindex].graphindex];
                }

            }

        }
        else
        {
            PlayerNode = MapGroup.GetNearestNode(Player.transform.position); // update player node
            UpdatePath(PlayerNode);
        }
    }

    public void Attack()
    {
        // melee the player
        print("ENEMY USED SPLASH");



    }


}
