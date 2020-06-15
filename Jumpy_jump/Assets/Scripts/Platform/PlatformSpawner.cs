using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private int ProbabilityOccurrence;
    private PlatformMov CurrentPlatform;

    private void Start()
    {
        ProbabilityOccurrence = 99;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        CurrentPlatform = temp.GetComponent<PlatformMov>();
        int rand = GetRandomNumber();

        if(CurrentPlatform == true && rand < ProbabilityOccurrence)
        {

            float posX = temp.GetComponent<SpriteRenderer>().bounds.max.x + temp.transform.localScale.x / 2;
            Vector3 instPos = new Vector3(posX, transform.position.y, 0);
            CreatePlatform(instPos);
        }
        else if(CurrentPlatform == true && rand >= ProbabilityOccurrence)
        {
            float posX = temp.GetComponent<SpriteRenderer>().bounds.max.x + temp.transform.localScale.x / 2;
            Vector3 instPos = new Vector3(posX, transform.position.y, 0);
            StartCoroutine(TryCreateAgain(instPos));
        }
   
    }

    private void CreatePlatform(Vector3 pos)
    {
        ObjectPool.Instans.GetObgectOfTag(CurrentPlatform.GetTag(), pos, transform, Quaternion.identity);
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

    private int GetRandomNumber()
    {
        int temp = Random.Range(0, 101);
        return temp;
    }


}
