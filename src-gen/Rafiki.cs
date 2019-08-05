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
		private readonly System.Random _Random;
		private int __DeadSeed
			 = default(int);
		public int DeadSeed { 
			get { return __DeadSeed; }
			set{
				if(__DeadSeed != value) __DeadSeed = value;
			}
		}
		private int __DeadSeedling
			 = default(int);
		public int DeadSeedling { 
			get { return __DeadSeedling; }
			set{
				if(__DeadSeedling != value) __DeadSeedling = value;
			}
		}
		private int __DeadJuvenile
			 = default(int);
		public int DeadJuvenile { 
			get { return __DeadJuvenile; }
			set{
				if(__DeadJuvenile != value) __DeadJuvenile = value;
			}
		}
		private int __DeadAdult
			 = default(int);
		public int DeadAdult { 
			get { return __DeadAdult; }
			set{
				if(__DeadAdult != value) __DeadAdult = value;
			}
		}
		private int __DieRandomProbability
			 = default(int);
		public int DieRandomProbability { 
			get { return __DieRandomProbability; }
			set{
				if(__DieRandomProbability != value) __DieRandomProbability = value;
			}
		}
		private int __DiePopulationDensity
			 = default(int);
		public int DiePopulationDensity { 
			get { return __DiePopulationDensity; }
			set{
				if(__DiePopulationDensity != value) __DiePopulationDensity = value;
			}
		}
		private int __DieDried
			 = default(int);
		public int DieDried { 
			get { return __DieDried; }
			set{
				if(__DieDried != value) __DieDried = value;
			}
		}
		private int __DieDrought
			 = default(int);
		public int DieDrought { 
			get { return __DieDrought; }
			set{
				if(__DieDrought != value) __DieDrought = value;
			}
		}
		private int __DieDamaged
			 = default(int);
		public int DieDamaged { 
			get { return __DieDamaged; }
			set{
				if(__DieDamaged != value) __DieDamaged = value;
			}
		}
		private int __DieFrozen
			 = default(int);
		public int DieFrozen { 
			get { return __DieFrozen; }
			set{
				if(__DieFrozen != value) __DieFrozen = value;
			}
		}
		private int __DieDeathZone
			 = default(int);
		public int DieDeathZone { 
			get { return __DieDeathZone; }
			set{
				if(__DieDeathZone != value) __DieDeathZone = value;
			}
		}
		private int __DiePushOver
			 = default(int);
		public int DiePushOver { 
			get { return __DiePushOver; }
			set{
				if(__DiePushOver != value) __DiePushOver = value;
			}
		}
		private int __DieRoundBarked
			 = default(int);
		public int DieRoundBarked { 
			get { return __DieRoundBarked; }
			set{
				if(__DieRoundBarked != value) __DieRoundBarked = value;
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
		private int __DT_Light
			 = default(int);
		public int DT_Light { 
			get { return __DT_Light; }
			set{
				if(__DT_Light != value) __DT_Light = value;
			}
		}
		private int __DT_Moderate
			 = default(int);
		public int DT_Moderate { 
			get { return __DT_Moderate; }
			set{
				if(__DT_Moderate != value) __DT_Moderate = value;
			}
		}
		private int __DT_Heavy
			 = default(int);
		public int DT_Heavy { 
			get { return __DT_Heavy; }
			set{
				if(__DT_Heavy != value) __DT_Heavy = value;
			}
		}
		private int __DT_Extreme
			 = default(int);
		public int DT_Extreme { 
			get { return __DT_Extreme; }
			set{
				if(__DT_Extreme != value) __DT_Extreme = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Save(
		string fact) {
			{
			string _switch30_782 = (fact);
			bool _matched_30_782 = false;
			bool _fallthrough_30_782 = false;
			if(!_matched_30_782 || _fallthrough_30_782) {
				if(Equals(_switch30_782, "SpawnedSeeds")) {
					_matched_30_782 = true;
					{
					SpawnedSeeds = SpawnedSeeds + 1
					;}
				} else {
					_fallthrough_30_782 = false;
				}
			}
			if(!_matched_30_782 || _fallthrough_30_782) {
				if(Equals(_switch30_782, "GrowedToSeedling")) {
					_matched_30_782 = true;
					{
					GrowedToSeedling = GrowedToSeedling + 1
					;}
				} else {
					_fallthrough_30_782 = false;
				}
			}
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SaveDamageType(
		SavannaTrees.DamageType damageType) {
			{
			if(Equals(damageType, DamageType.Light)) {
							{
							DT_Light = DT_Light + 1
							;}
					;} else {
							if(Equals(damageType, DamageType.Moderate)) {
											{
											DT_Moderate = DT_Moderate + 1
											;}
									;} else {
											if(Equals(damageType, DamageType.Heavy)) {
															{
															DT_Heavy = DT_Heavy + 1
															;}
													;} else {
															if(Equals(damageType, DamageType.Extreme)) {
																			{
																			DT_Extreme = DT_Extreme + 1
																			;}
																	;} 
														;}
										;}
						;}
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
							DeadSeed = DeadSeed + 1
							;}
					;} else {
							if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
											{
											DeadSeedling = DeadSeedling + 1
											;}
									;} else {
											if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
															{
															DeadJuvenile = DeadJuvenile + 1
															;}
													;} else {
															if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																			{
																			DeadAdult = DeadAdult + 1
																			;}
																	;} 
														;}
										;}
						;};
			string _switch59_1717 = (fact);
			bool _matched_59_1717 = false;
			bool _fallthrough_59_1717 = false;
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "Drought")) {
					_matched_59_1717 = true;
					{
					DieDrought = DieDrought + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "RandomProbability")) {
					_matched_59_1717 = true;
					{
					DieRandomProbability = DieRandomProbability + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "PopulationDensity")) {
					_matched_59_1717 = true;
					{
					DiePopulationDensity = DiePopulationDensity + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "Dried")) {
					_matched_59_1717 = true;
					{
					DieDried = DieDried + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "Damaged")) {
					_matched_59_1717 = true;
					{
					DieDamaged = DieDamaged + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "Frozen")) {
					_matched_59_1717 = true;
					{
					DieFrozen = DieFrozen + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "DeathZone")) {
					_matched_59_1717 = true;
					{
					DieDeathZone = DieDeathZone + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "PushOver")) {
					_matched_59_1717 = true;
					{
					DiePushOver = DiePushOver + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
				}
			}
			if(!_matched_59_1717 || _fallthrough_59_1717) {
				if(Equals(_switch59_1717, "RoundBarked")) {
					_matched_59_1717 = true;
					{
					DieRoundBarked = DieRoundBarked + 1
					;}
				} else {
					_fallthrough_59_1717 = false;
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
		 : base (ycor, xcor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			_Random = new System.Random(ID.GetHashCode());
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
			DeadSeed = 0;
			DeadSeedling = 0;
			DeadJuvenile = 0;
			DeadAdult = 0;
			DieRandomProbability = 0;
			DiePopulationDensity = 0;
			DieDried = 0;
			DieDrought = 0;
			DieDamaged = 0;
			DieFrozen = 0;
			DiePopulationDensity = 0;
			DieDeathZone = 0;
			SpawnedSeeds = 0;
			GrowedToSeedling = 0;
			DT_Light = 0;
			DT_Moderate = 0;
			DT_Heavy = 0;
			DT_Extreme = 0
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Rafiki other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
