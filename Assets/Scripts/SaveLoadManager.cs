using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {
	public static void SaveScore(int score) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/highscore.puppersave", FileMode.Create);

		ScoreData data = new ScoreData(score);

		bf.Serialize(stream, data);
		stream.Close();
	}

	public static int LoadScore() {
		if (File.Exists (Application.persistentDataPath + "/highscore.puppersave")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/highscore.puppersave", FileMode.Open);

			ScoreData data = (ScoreData)bf.Deserialize (stream);

			stream.Close ();
			return data.highscore;
		} else {
			return 0;
		}
	}
}

[Serializable]
public class ScoreData {

	public int highscore;

	public ScoreData(int score) {
		highscore = score;
	}
}
