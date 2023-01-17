using HarmonyLib;
using NeosModLoader;
using FrooxEngine;

namespace NeosNonPersistentInspectors {
	public class NeosNonPersistentInspectors : NeosMod {
		public override string Name => "NeosNonPersistentInspectors";
		public override string Author => "Delta";
		public override string Version => "1.0.0";
		public override string Link => "https://github.com/XDelta/NeosNonPersistentInspectors/";

		public override void OnEngineInit() {
			Harmony harmony = new Harmony("net.deltawolf.NeosNonPersistentInspectors");
			harmony.PatchAll();
			Msg("Inspectors NonPersistent'd!");
		}

		[HarmonyPatch(typeof(SceneInspector), "OnAttach")]
		static class SceneInspector_OnAttach_Patch {
			static void Postfix(SceneInspector __instance) {
				__instance.Slot.PersistentSelf = false;
			}
		}
	}
}