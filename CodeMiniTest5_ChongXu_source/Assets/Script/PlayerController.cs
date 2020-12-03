using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int EnergyCount = 0;
    int speed = 10;
    public Animator PlayerAnimation;
    public GameObject PlayerGO;
    public GameObject EnergyCube;
    public Text Energy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Energy.text = ("Energy : " + EnergyCount);

        if (GMController.gmInstance.levelTime > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnimation.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                PlayerAnimation.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnimation.SetBool("Move", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnimation.SetBool("Move", true);
            }
            else
            {
                PlayerAnimation.SetBool("Move", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            PlayerAnimation.SetBool("Move", false);
        }

        if ( EnergyCount >= 30)
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (EnergyCount < 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Energy"))
        {
            EnergyCount += 5;
            Destroy(other.gameObject);
            GMController.gmInstance.AddTime();
        }
        else if (other.gameObject.CompareTag("Energys"))
        {
            EnergyCount -= 10;
            Destroy(other.gameObject);
            GMController.gmInstance.AddTime();
        }
    }
}
