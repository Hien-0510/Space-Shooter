using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Formation{
    public GameObject enemyPrefabs;
    public int enemyCount;
    public float enemyDelay;
    public Route route;
    public float Speed;
    public float formationDelay;
}
public class EnemySpawner : MonoBehaviour
{
    public Formation[] formations;
    public GameObject bossPrefabs;
    public float bossDelay;
    public Route bossRoute;
    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(SpawnFormations());
        StartCoroutine(SpawnBoss());
    }


    private IEnumerator SpawnFormations(){
        for (int i = 0; i < formations.Length; i++){
            yield return new WaitForSeconds(formations[i].formationDelay);
            SpawnEnemies(formations[i]);
        }
    }

    private void SpawnEnemies(Formation formation){
        for(int i=0; i < formation.enemyCount; i++){
            GameObject enemy = Instantiate(formation.enemyPrefabs, formation.route[0], Quaternion.identity);
            RoutingAgent agent = enemy.GetComponent<RoutingAgent>();
            agent.route = formation.route;
            agent.delay = i * formation.enemyDelay;
            agent.flySpeed = formation.Speed;
        }
    }

    private IEnumerator SpawnBoss(){
        yield return new WaitForSeconds(bossDelay);
        GameObject boss = Instantiate(bossPrefabs);
        boss.GetComponent<RoutingAgent>().route = bossRoute;
    }

}

