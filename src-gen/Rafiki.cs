namespace SavannaTrees {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	// ReSharper disable All
	#pragma warning disable 162
	#pragma warning disable 219
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "InconsistentNaming")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantNameQualifier")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantCheckBeforeAssignment")]
	public class Rafiki : Mars.Interfaces.Environment.GeoCommon.GeoPosition, Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Rafiki));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private int __Seed
			 = default(int);
		public int Seed { 
			get { return __Seed; }
			set{
				if(__Seed != value) __Seed = value;
			}
		}
		private int __Seedling
			 = default(int);
		public int Seedling { 
			get { return __Seedling; }
			set{
				if(__Seedling != value) __Seedling = value;
			}
		}
		private int __Juvenile
			 = default(int);
		public int Juvenile { 
			get { return __Juvenile; }
			set{
				if(__Juvenile != value) __Juvenile = value;
			}
		}
		private int __Adult
			 = default(int);
		public int Adult { 
			get { return __Adult; }
			set{
				if(__Adult != value) __Adult = value;
			}
		}
		private int __RandomProbability
			 = default(int);
		public int RandomProbability { 
			get { return __RandomProbability; }
			set{
				if(__RandomProbability != value) __RandomProbability = value;
			}
		}
		private int __PopulationDensity
			 = default(int);
		public int PopulationDensity { 
			get { return __PopulationDensity; }
			set{
				if(__PopulationDensity != value) __PopulationDensity = value;
			}
		}
		private int __Dried
			 = default(int);
		public int Dried { 
			get { return __Dried; }
			set{
				if(__Dried != value) __Dried = value;
			}
		}
		private int __Drought
			 = default(int);
		public int Drought { 
			get { return __Drought; }
			set{
				if(__Drought != value) __Drought = value;
			}
		}
		private int __Damaged
			 = default(int);
		public int Damaged { 
			get { return __Damaged; }
			set{
				if(__Damaged != value) __Damaged = value;
			}
		}
		private int __Frozen
			 = default(int);
		public int Frozen { 
			get { return __Frozen; }
			set{
				if(__Frozen != value) __Frozen = value;
			}
		}
		private int __DeathZone
			 = default(int);
		public int DeathZone { 
			get { return __DeathZone; }
			set{
				if(__DeathZone != value) __DeathZone = value;
			}
		}
		private int __PushOver
			 = default(int);
		public int PushOver { 
			get { return __PushOver; }
			set{
				if(__PushOver != value) __PushOver = value;
			}
		}
		private int __RoundBarked
			 = default(int);
		public int RoundBarked { 
			get { return __RoundBarked; }
			set{
				if(__RoundBarked != value) __RoundBarked = value;
			}
		}
		private int __SpawnedSeeds
			 = default(int);
		public int SpawnedSeeds { 
			get { return __SpawnedSeeds; }
			set{
				if(__SpawnedSeeds != value) __SpawnedSeeds = value;
			}
		}
		private int __GrowedToSeedling
			 = default(int);
		public int GrowedToSeedling { 
			get { return __GrowedToSeedling; }
			set{
				if(__GrowedToSeedling != value) __GrowedToSeedling = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Save(
		string fact) {
			{
			string _switch25_604 = (fact);
			bool _matched_25_604 = false;
			bool _fallthrough_25_604 = false;
			if(!_matched_25_604 || _fallthrough_25_604) {
				if(Equals(_switch25_604, "SpawnedSeeds")) {
					_matched_25_604 = true;
					{
					SpawnedSeeds = SpawnedSeeds + 1
					;}
				} else {
					_fallthrough_25_604 = false;
				}
			}
			if(!_matched_25_604 || _fallthrough_25_604) {
				if(Equals(_switch25_604, "GrowedToSeedling")) {
					_matched_25_604 = true;
					{
					GrowedToSeedling = GrowedToSeedling + 1
					;}
				} else {
					_fallthrough_25_604 = false;
				}
			}
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SaveDyingReason(
		string fact,
		SavannaTrees.TreeAgeGroup treeAgeGroup) {
			{
			if(Equals(treeAgeGroup, TreeAgeGroup.Seed)) {
							{
							Seed = Seed + 1
							;}
					;} else {
							if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
											{
											Seedling = Seedling + 1
											;}
									;} else {
											if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
															{
															Juvenile = Juvenile + 1
															;}
													;} else {
															if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																			{
																			Adult = Adult + 1
																			;}
																	;} 
														;}
										;}
						;};
			string _switch42_1141 = (fact);
			bool _matched_42_1141 = false;
			bool _fallthrough_42_1141 = false;
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "Drought")) {
					_matched_42_1141 = true;
					{
					Drought = Drought + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "RandomProbability")) {
					_matched_42_1141 = true;
					{
					RandomProbability = RandomProbability + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "PopulationDensity")) {
					_matched_42_1141 = true;
					{
					PopulationDensity = PopulationDensity + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "Dried")) {
					_matched_42_1141 = true;
					{
					Dried = Dried + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "Damaged")) {
					_matched_42_1141 = true;
					{
					Damaged = Damaged + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "Frozen")) {
					_matched_42_1141 = true;
					{
					Frozen = Frozen + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "DeathZone")) {
					_matched_42_1141 = true;
					{
					DeathZone = DeathZone + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "PushOver")) {
					_matched_42_1141 = true;
					{
					PushOver = PushOver + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			if(!_matched_42_1141 || _fallthrough_42_1141) {
				if(Equals(_switch42_1141, "RoundBarked")) {
					_matched_42_1141 = true;
					{
					RoundBarked = RoundBarked + 1
					;}
				} else {
					_fallthrough_42_1141 = false;
				}
			}
			;}
			
			return;
		}
		internal bool _isAlive;
		internal int _executionFrequency;
		
		public SavannaTrees.SavannaLayer _Layer_ => _SavannaLayer;
		public SavannaTrees.SavannaLayer _SavannaLayer { get; set; }
		public SavannaTrees.Precipitation _Precipitation { get; set; }
		public SavannaTrees.Precipitation precipitation => _Precipitation;
		public SavannaTrees.Temperature _Temperature { get; set; }
		public SavannaTrees.Temperature temperature => _Temperature;
		public SavannaTrees.TreeRaster _TreeRaster { get; set; }
		public SavannaTrees.TreeRaster treeRaster => _TreeRaster;
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Rafiki (
		System.Guid _id,
		SavannaTrees.SavannaLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Rafiki> _RafikiEnvironment,
		SavannaTrees.Precipitation _Precipitation,
		SavannaTrees.Temperature _Temperature,
		SavannaTrees.TreeRaster _TreeRaster
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			this._TreeRaster = _TreeRaster;
			_SavannaLayer._RafikiEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
			{
			Seed = 0;
			Seedling = 0;
			Juvenile = 0;
			Adult = 0;
			RandomProbability = 0;
			PopulationDensity = 0;
			Dried = 0;
			Drought = 0;
			Damaged = 0;
			Frozen = 0;
			PopulationDensity = 0;
			DeathZone = 0;
			SpawnedSeeds = 0;
			GrowedToSeedling = 0
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Rafiki other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
