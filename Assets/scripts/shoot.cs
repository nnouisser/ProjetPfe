using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Rigidbody spherePrefab; // Référence à la sphère prefab
    public float speed = 2000f;
    public GameObject RealStick;
    public AudioSource shootSound;
    public RawImage crosshairImage; // Référence à l'image du crosshair

    public Button shootButton; // Référence au bouton Shoot

    // Start est appelée avant le premier frame update
    void Start()
    {
    }

    // Méthode pour gérer le tir
    public void Shooting()
    {
        // Obtenez la position de la caméra
        Vector3 cameraPosition = Camera.main.transform.position;

        // Obtenez la direction du centre de l'écran à partir de la caméra
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Vector3 shootDirection = ray.direction;

        // Instanciez la sphère à partir de la position de la caméra avec une rotation vers la direction de tir
        Rigidbody newSphere = Instantiate(spherePrefab, cameraPosition, Quaternion.LookRotation(shootDirection));

        // Ajoutez une force à la sphère dans la direction du centre de l'écran
        newSphere.AddForce(shootDirection * speed);

        // Jouez l'animation RealStick
        RealStick.GetComponent<Animation>().Play("StickShot");

        // Jouez le son de tir
        shootSound.Play();
    }
}
