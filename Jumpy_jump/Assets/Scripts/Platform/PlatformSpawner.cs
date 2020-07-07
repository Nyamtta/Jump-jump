using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private const int Min_Chance_Inst_Platform = 0;
    private const int Max_Chance_Inst_Platform = 101; // random.range 101 = 100

    private int ProbabilityOccurrence;
    private ObstacleControler CurrentPlatform;
    private float ComplexityLevel;

    private void Start()
    {
        ProbabilityOccurrence = 100;
        ComplexityLevel = 99;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<ObstacleControler>() == false)
        {
            return;
        }

        Vector3 instPos = new Vector3(
            (collision.GetComponent<ObstacleControler>().GetLeftTopSpritePos().x + 1.5f), 
            transform.position.y, transform.position.z);

        CurrentPlatform = collision.GetComponent<ObstacleControler>();

        int chanceInst = GetRandomNumber();

        if(chanceInst <= ProbabilityOccurrence)
        {
            CreatePlatform(instPos);
        }
        else
        {
            StartCoroutine(TryCreateAgain(instPos));
        }
    }

    private void CreatePlatform(Vector3 pos)
    {
        ObjectPool.Instans.GetObgectOfTag(CurrentPlatform.GetTag(), pos, transform, Quaternion.identity);
    }

    private int GetRandomNumber()
    {
        int temp = Random.Range(0, 101);
        return temp;
    }

    IEnumerator TryCreateAgain(Vector3 pos)
    {
        yield return new WaitForSeconds(1.5f);

        if(GetRandomNumber() < ProbabilityOccurrence)
        {
            CreatePlatform(pos);
        }
        else
        {
            yield return StartCoroutine(TryCreateAgain(pos));
        }

    }

}
