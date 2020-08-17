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

namespace RPG_Campaign_Planner.Parcelables {
	public class GenericParcelableCreator<T> : Java.Lang.Object, IParcelableCreator where T : Java.Lang.Object, new() {
		/// <summary>
		/// Fuinction for the creation of a parcel
		/// </summary>
		private readonly Func<Parcel, T> _createFunc;

		/// <summary>
		/// Initialize an instance of the GenericParcelableCreator
		/// </summary>
		/// <param name="createFromParcelFunc"></param>
		public GenericParcelableCreator(Func<Parcel, T> createFromParcelFunc) {
			_createFunc = createFromParcelFunc;
		}

		/// <summary>
		/// Create a parcelable from a parcel
		/// </summary>
		/// <param name="parcel"></param>
		/// <returns></returns>
		public Java.Lang.Object CreateFromParcel(Parcel parcel) {
			return _createFunc(parcel);
		}

		/// <summary>
		/// Create an array from the parcelable class
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public Java.Lang.Object[] NewArray(int size) {
			return new T[size];
		}
	}
}