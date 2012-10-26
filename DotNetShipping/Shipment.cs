using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DotNetShipping
{
	/// <summary>
	/// 	Summary description for Shipment.
	/// </summary>
	public class Shipment
	{
		#region Fields

		public readonly Address DestinationAddress;
		public readonly Address OriginAddress;
		public readonly string TrackingNumber;
		private readonly List<Rate> _rates;
		private readonly List<TrackingActivity> _trackingActivities;
		public ReadOnlyCollection<Package> Packages;

		#endregion

		#region .ctor

		public Shipment(Address originAddress, Address destinationAddress, Package package)
		{
			OriginAddress = originAddress;
			DestinationAddress = destinationAddress;
			var packages = new List<Package>();
			packages.Add(package);
			Packages = packages.AsReadOnly();
			_rates = new List<Rate>();
		}

		public Shipment(Address originAddress, Address destinationAddress, List<Package> packages)
		{
			OriginAddress = originAddress;
			DestinationAddress = destinationAddress;
			Packages = packages.AsReadOnly();
			_rates = new List<Rate>();
		}

		internal Shipment(string trackingNumber)
		{
			TrackingNumber = trackingNumber;
			_trackingActivities = new List<TrackingActivity>();
		}

		#endregion

		#region Properties

		public ReadOnlyCollection<Rate> Rates
		{
			get { return _rates.AsReadOnly(); }
		}

		public ReadOnlyCollection<TrackingActivity> TrackingActivities
		{
			get { return _trackingActivities.AsReadOnly(); }
		}

		internal List<Rate> rates
		{
			get { return _rates; }
		}

		internal List<TrackingActivity> trackingActivities
		{
			get { return _trackingActivities; }
		}

		#endregion
	}
}