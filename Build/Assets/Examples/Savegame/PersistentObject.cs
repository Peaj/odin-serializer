using System.Collections;
using System.Collections.Generic;
using System.IO;
using OdinSerializer;
using UnityEngine;

public class PersistentObject : MonoBehaviour {

	public string Path { get { return Application.streamingAssetsPath + "/savegame.sav"; }}

	[ContextMenu("Save")]
	public void Save()
	{
		using (var stream = new FileStream(this.Path, FileMode.Create))
		{
			var context = new SerializationContext();
			// var policy = SerializationPolicies.Unity;
			// context.Config.SerializationPolicy = policy;
			var writer = SerializationUtility.CreateWriter(stream, context, DataFormat.JSON);
			var serializer = Serializer.Get<Transform>();
			serializer.WriteValue(this.transform,writer);
			writer.FlushToStream();
		}
	}

	[ContextMenu("Load")]
	public void Load()
	{
		using (var stream = new FileStream(this.Path, FileMode.Open))
		{
			var context = new DeserializationContext();
			// var policy = SerializationPolicies.Unity;
			// context.Config.SerializationPolicy = policy;
			var reader = SerializationUtility.CreateReader(stream, context, DataFormat.JSON);
			var serializer = Serializer.Get<Transform>();
			serializer.ReadValue(reader);
		}
	}
}
