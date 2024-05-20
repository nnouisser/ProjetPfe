using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Rigidbody spherePrefab; // R�f�rence � la sph�re prefab
    public float speed = 2000f;
    public GameObject RealStick;
    public AudioSource shootSound;
    public RawImage crosshairImage; // R�f�rence � l'image du crosshair

    public Button shootButton; // R�f�rence au bouton Shoot

    // Start est appel�e avant le premier frame update
    void Start()
    {
    }

    // M�thode pour g�rer le tir
    public void Shooting()
    {
        // Obtenez la position de la cam�ra
        Vector3 cameraPosition = Camera.main.transform.position;

        // Obtenez la direction du centre de l'�cran � partir de la cam�ra
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 shootDirection = ray.direction;

        // Instanciez la sph�re � partir de la position de la cam�ra avec une rotation vers la direction de tir
        Rigidbody newSphere = Instantiate(spherePrefab, cameraPosition, Quaternion.LookRotation(shootDirection));

        // Ajoutez une force � la sph�re dans la direction du centre de l'�cran
        newSphere.AddForce(shootDirection * speed);

        // Jouez l'animation RealStick
        RealStick.GetComponent<Animation>().Play("StickShot");

        // Jouez le son de tir
        shootSound.Play();
    }
}
