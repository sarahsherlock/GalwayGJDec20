using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PotionFiller : MonoBehaviour
{
	[SerializeField] private Potion[] potions;
	private void OnTriggerEnter(Collider other)
	{
		var bottle = other.GetComponent<Bottle>();
		if (bottle)
		{
			bottle.SetPotion(0);
			var potionBehaviour = bottle.gameObject.AddComponent<PotionBehaviour>();
			potionBehaviour.potionMaterials = new Material[bottle.potions.Length];
			for (var i = 0; i < bottle.potions.Length; i++)
			{
				potionBehaviour.potionMaterials[i] = bottle.potions[i].potionMaterial;
			}
		}
	}
}