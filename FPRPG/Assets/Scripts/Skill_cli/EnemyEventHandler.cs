using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class EnemyEventHandler : MonoBehaviour {

	public GameObject lightningPrefab = null; 
	public Transform sfxSpawnTransform;

	private Animator enemyAnimator = null;

	private float m_nHitTime = 0.0f;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponent<Animator>();
	}

	void OnEnable()
	{
		GameManager.onEnemyAttacked += OnEnemyAttackedHandler;
	}

	void OnDisable()
	{
		GameManager.onEnemyAttacked -= OnEnemyAttackedHandler;
	}

	void OnEnemyAttackedHandler()
	{
		Debug.Log("Enemy Attacked");

		enemyAnimator.SetBool("bHit", true);
		m_nHitTime = Time.time + 0.4f;

		// SFX 오브젝트를 만든다
		GameObject newSFX = (GameObject)Instantiate(lightningPrefab);
		// SFX 출력 위치를 설정한다
		newSFX.transform.position = sfxSpawnTransform.position;
		
		SFXController SFXCon = newSFX.GetComponent<SFXController>();
		SFXCon.playerObject = gameObject;
		SFXCon.LaunchSFX();
	}

	// Update is called once per frame
	void Update () {
		if (m_nHitTime > 0.0f)
		{
			if (m_nHitTime < Time.time)
			{
				enemyAnimator.SetBool("bHit", false);
			}
		}
	}
}
