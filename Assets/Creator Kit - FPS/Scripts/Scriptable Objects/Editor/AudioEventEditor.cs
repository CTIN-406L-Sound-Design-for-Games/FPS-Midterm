using UnityEditor;
using UnityEngine;

namespace CTIN_406L_Starter_Pack.Scriptable_Objects.Audio.Editor
{
	[CustomEditor(typeof(SoundSO), true)]
	public class AudioEventEditor : UnityEditor.Editor
	{
		string gameobjectName = "-> Sound Object Preview <-";
		[SerializeField] private AudioSource _play;


		public void OnEnable()
		{
			_play = EditorUtility.CreateGameObjectWithHideFlags
			(gameobjectName, HideFlags.None,
				typeof(AudioSource)).GetComponent<AudioSource>();
			
			((SoundSO) target).SetDefaultParameters();
		}

		public void OnDisable()
		{
			if (_play.gameObject != null)
			{
				DestroyImmediate(_play.gameObject);
			}
		}

		public override void OnInspectorGUI()
		{


			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Play"))
			{
				((SoundSO) target).Play(_play);
				 _play.name = "-> "+ SoundSO.nowPlaying + " <-";
			}
			if (GUILayout.Button("Stop"))
			{
				_play.Stop();
			}

			EditorGUI.EndDisabledGroup();
			DrawDefaultInspector();
		}
	}
}
