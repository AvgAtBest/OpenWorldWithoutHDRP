using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class EditModeTestRunner
	{
		// A Test behaves as an ordinary method
		[Test]
		public void Player_Exists_By_Name()
		{
			// Use the Assert class to test conditions
			var player = GameObject.Find("Player");
			Assert.IsTrue(player != null);
		}

		[Test]
		public void Player_Exists_By_Type()
		{
			var player = GameObject.FindObjectOfType<Player>();

			Assert.IsTrue(player != null);
		}
		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
		public IEnumerator Player_Took_Damage()
		{
			var player = GameObject.FindObjectOfType<Player>();

			var oldHealth = player.health;

			yield return new WaitForSecondsRealtime(5);

			Assert.IsTrue(player.health != oldHealth);

		}
	}
}
