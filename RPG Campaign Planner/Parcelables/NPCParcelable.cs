using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using models;

namespace RPG_Campaign_Planner.Parcelables {
	public class NPCParcelable : Java.Lang.Object, IParcelable{

		private static readonly GenericParcelableCreator<NPCParcelable> _creator
			= new GenericParcelableCreator<NPCParcelable>((parcel) => new NPCParcelable(parcel));

		public NPC NPC { get; set; }

		public NPCParcelable() {

		}

		private NPCParcelable(Parcel parcel) {
			NPC = new NPC {
				Name = parcel.ReadString(),
				Appearance = parcel.ReadString(),
				Quote = parcel.ReadString(),
				Roleplaying = parcel.ReadString(),
				Background = parcel.ReadString(),
				KeyInfo = parcel.ReadString(),
				StatBlock = parcel.ReadString()
			};
		}

		public int DescribeContents() {
			return 0;
		}

		public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags) {
			dest.WriteString(NPC.Name);
			dest.WriteString(NPC.Appearance);
			dest.WriteString(NPC.Quote);
			dest.WriteString(NPC.Roleplaying);
			dest.WriteString(NPC.Background);
			dest.WriteString(NPC.KeyInfo);
			dest.WriteString(NPC.StatBlock);
		}

		[ExportField("CREATOR")]
		public static GenericParcelableCreator<NPCParcelable> GetCreator() {
			return _creator;
		}
	}
}