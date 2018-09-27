using OdinSerializer;
using UnityEngine;

[assembly: RegisterFormatter(typeof(TransformFormatter))]
	
public class TransformFormatter : MinimalBaseFormatter<Transform>
{
	private static readonly Serializer<Vector3> Vector3Serializer = Serializer.Get<Vector3>();
	private static readonly Serializer<Quaternion> QuaternionSerializer = Serializer.Get<Quaternion>();

	protected override void Read(ref Transform value, IDataReader reader)
	{
		Debug.Log("ReadTransform");
		value.localPosition = Vector3Serializer.ReadValue(reader);
		value.localRotation = QuaternionSerializer.ReadValue(reader);
		value.localScale = Vector3Serializer.ReadValue(reader);
	}

	
	protected override void Write(ref Transform value, IDataWriter writer)
	{
		Vector3Serializer.WriteValue("localPosition", value.localPosition, writer);
		QuaternionSerializer.WriteValue("localRotation", value.localRotation, writer);
		Vector3Serializer.WriteValue("localScale", value.localScale, writer);
	}
}