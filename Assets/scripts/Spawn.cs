using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab de l'ennemi
    public float spawnInterval = 3f;  // Intervalle de spawn en secondes
    public int maxEnemies = 5;  // Nombre maximum d'ennemis autorisés simultanément
    private int currentEnemies = 0;  // Nombre d'ennemis actuellement présents

    // Start is called before the first frame update
    void Start()
    {
        // Commencez à appeler la fonction SpawnEnemy à intervalles spécifiés
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Fonction pour générer un ennemi
    void SpawnEnemy()
    {
        // Vérifiez si le nombre d'ennemis actuellement présents est inférieur au maximum autorisé
        if (currentEnemies < maxEnemies)
        {
            // Instancier un nouvel ennemi à la position actuelle du Spawn
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Incrémentez le nombre d'ennemis actuellement présents
            currentEnemies++;
        }
    }

    // Fonction appelée lorsque le zombie est tué
    public void EnemyKilled()
    {
        // Décrémentez le nombre d'ennemis actuellement présents
        currentEnemies = Mathf.Max(0, currentEnemies - 1);
    }
}
