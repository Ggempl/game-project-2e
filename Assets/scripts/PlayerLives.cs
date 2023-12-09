using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public PauseMenu pauseMenu;
    [SerializeField] private AudioClip EnemyImpactSoundClip;
    [SerializeField] private AudioClip EnemyProjectileImpactSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            lives -= 1;
            SoundFXManger.instance.PlaySoundFXClip(EnemyImpactSoundClip, transform, 1f);
            for (int i = 0; i < livesUI.Length; i++)
            {
                if(i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0) 
            {
                Destroy(gameObject);
                pauseMenu.PauseGame();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Projectile")
        {
            Destroy(collision.gameObject);
            lives -= 1;
            SoundFXManger.instance.PlaySoundFXClip(EnemyProjectileImpactSoundClip, transform, 1f);
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                pauseMenu.PauseGame();
            }
        }
    }
}
