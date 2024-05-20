using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab de l'ennemi
    public float spawnInterval = 3f;  // Intervalle de spawn en secondes
    public int maxEnemies = 5;  // Nombre maximum d'ennemis autoris�s simultan�ment
    private int currentEnemies = 0;  // Nombre d'ennemis actuellement pr�sents

    // Start is called before the first frame update
    void Start()
    {
        // Commencez � appeler la fonction SpawnEnemy � intervalles sp�cifi�s
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Fonction pour g�n�rer un ennemi
    void SpawnEnemy()
    {
        // V�rifiez si le nombre d'ennemis actuellement pr�sents est inf�rieur au maximum autoris�
        if (currentEnemies < maxEnemies)
        {
            // Instancier un nouvel ennemi � la position actuelle du Spawn
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Incr�mentez le nombre d'ennemis actuellement pr�sents
            currentEnemies++;
        }
    }

    // Fonction appel�e lorsque le zombie est tu�
    public void EnemyKilled()
    {
        // D�cr�mentez le nombre d'ennemis actuellement pr�sents
        currentEnemies = Mathf.Max(0, currentEnemies - 1);
    }
}
