using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthRestored)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = healthRestored.ToString();
    }

    public void OnExitGame(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started)
        {
        #if (UNITY_EDITOR || DEVELOPEMENT_BUILD)
                  Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
         #endif

         #if (UNITY_EDITOR) 
                   UnityEditor.EditorApplication.isPlaying = false;
         #elif (UNITY_STANDLONE)
                    Application.Quit();
         #elif (UNITY_WEBGL)
                    SceneManager.LoadScene("QuitScene");
         #endif




        }
    }
}

