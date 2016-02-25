using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour
{
    enum AttackType
    {
        Paper,
        Rock,
        Scissors,
    }

    Animation _ani = null;
    GameObject _paper = null;
    GameObject _rock = null;
    GameObject _scissors = null;

    AttackType _curAttackType = AttackType.Paper;

    void Awake()
    {
        _ani = transform.GetComponent<Animation>();

        MeshRenderer[] meshes = transform.GetComponentsInChildren<MeshRenderer>();

        foreach(var mesh in meshes)
        {
            if("Paper_2" == mesh.name)
            {
                _paper = mesh.gameObject;
            }
            else if("Rock_2" == mesh.name)
            {
                _rock = mesh.gameObject;
            }
            else if("Scissors_2" == mesh.name)
            {
                _scissors = mesh.gameObject;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _curAttackType = AttackType.Paper;
            _ani.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _curAttackType = AttackType.Rock;
            _ani.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _curAttackType = AttackType.Scissors;
            _ani.Play();
        }
    }

    void OnAniEvent()
    {
        switch(_curAttackType)
        {
            case AttackType.Paper:
                _paper.SetActive(true);
                _rock.SetActive(false);
                _scissors.SetActive(false);
                break;

            case AttackType.Rock:
                _paper.SetActive(false);
                _rock.SetActive(true);
                _scissors.SetActive(false);
                break;

            case AttackType.Scissors:
                _paper.SetActive(false);
                _rock.SetActive(false);
                _scissors.SetActive(true);
                break;
        }
    }
}
