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
		private int __droughtSeed
			 = default(int);
		public int droughtSeed { 
			get { return __droughtSeed; }
			set{
				if(__droughtSeed != value) __droughtSeed = value;
			}
		}
		private int __droughtSeedling
			 = default(int);
		public int droughtSeedling { 
			get { return __droughtSeedling; }
			set{
				if(__droughtSeedling != value) __droughtSeedling = value;
			}
		}
		private int __droughtJuvenile
			 = default(int);
		internal int droughtJuvenile { 
			get { return __droughtJuvenile; }
			set{
				if(__droughtJuvenile != value) __droughtJuvenile = value;
			}
		}
		private int __droughtAdult
			 = default(int);
		internal int droughtAdult { 
			get { return __droughtAdult; }
			set{
				if(__droughtAdult != value) __droughtAdult = value;
			}
		}
		private int __randomSeed
			 = default(int);
		public int randomSeed { 
			get { return __randomSeed; }
			set{
				if(__randomSeed != value) __randomSeed = value;
			}
		}
		private int __randomSeedling
			 = default(int);
		internal int randomSeedling { 
			get { return __randomSeedling; }
			set{
				if(__randomSeedling != value) __randomSeedling = value;
			}
		}
		private int __randomJuvenile
			 = default(int);
		internal int randomJuvenile { 
			get { return __randomJuvenile; }
			set{
				if(__randomJuvenile != value) __randomJuvenile = value;
			}
		}
		private int __randomAdult
			 = default(int);
		internal int randomAdult { 
			get { return __randomAdult; }
			set{
				if(__randomAdult != value) __randomAdult = value;
			}
		}
		private int __populationDensitySeed
			 = default(int);
		public int populationDensitySeed { 
			get { return __populationDensitySeed; }
			set{
				if(__populationDensitySeed != value) __populationDensitySeed = value;
			}
		}
		private int __populationDensitySeedling
			 = default(int);
		internal int populationDensitySeedling { 
			get { return __populationDensitySeedling; }
			set{
				if(__populationDensitySeedling != value) __populationDensitySeedling = value;
			}
		}
		private int __populationDensityJuvenile
			 = default(int);
		internal int populationDensityJuvenile { 
			get { return __populationDensityJuvenile; }
			set{
				if(__populationDensityJuvenile != value) __populationDensityJuvenile = value;
			}
		}
		private int __populationDensityAdult
			 = default(int);
		internal int populationDensityAdult { 
			get { return __populationDensityAdult; }
			set{
				if(__populationDensityAdult != value) __populationDensityAdult = value;
			}
		}
		private int __driedSeed
			 = default(int);
		public int driedSeed { 
			get { return __driedSeed; }
			set{
				if(__driedSeed != value) __driedSeed = value;
			}
		}
		private int __driedSeedling
			 = default(int);
		public int driedSeedling { 
			get { return __driedSeedling; }
			set{
				if(__driedSeedling != value) __driedSeedling = value;
			}
		}
		private int __driedJuvenile
			 = default(int);
		internal int driedJuvenile { 
			get { return __driedJuvenile; }
			set{
				if(__driedJuvenile != value) __driedJuvenile = value;
			}
		}
		private int __driedAdult
			 = default(int);
		internal int driedAdult { 
			get { return __driedAdult; }
			set{
				if(__driedAdult != value) __driedAdult = value;
			}
		}
		private int __damagedSeedling
			 = default(int);
		public int damagedSeedling { 
			get { return __damagedSeedling; }
			set{
				if(__damagedSeedling != value) __damagedSeedling = value;
			}
		}
		private int __damagedJuvenile
			 = default(int);
		internal int damagedJuvenile { 
			get { return __damagedJuvenile; }
			set{
				if(__damagedJuvenile != value) __damagedJuvenile = value;
			}
		}
		private int __damagedAdult
			 = default(int);
		internal int damagedAdult { 
			get { return __damagedAdult; }
			set{
				if(__damagedAdult != value) __damagedAdult = value;
			}
		}
		private int __frozenSeedling
			 = default(int);
		internal int frozenSeedling { 
			get { return __frozenSeedling; }
			set{
				if(__frozenSeedling != value) __frozenSeedling = value;
			}
		}
		private int __frozenJuvenile
			 = default(int);
		internal int frozenJuvenile { 
			get { return __frozenJuvenile; }
			set{
				if(__frozenJuvenile != value) __frozenJuvenile = value;
			}
		}
		private int __frozenAdult
			 = default(int);
		internal int frozenAdult { 
			get { return __frozenAdult; }
			set{
				if(__frozenAdult != value) __frozenAdult = value;
			}
		}
		private int __seedAcc
			 = default(int);
		public int seedAcc { 
			get { return __seedAcc; }
			set{
				if(__seedAcc != value) __seedAcc = value;
			}
		}
		private int __growToSeedling
			 = default(int);
		public int growToSeedling { 
			get { return __growToSeedling; }
			set{
				if(__growToSeedling != value) __growToSeedling = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void AccSeed() {
			{
			seedAcc = seedAcc + 1
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowToSeedling() {
			{
			growToSeedling = growToSeedling + 1
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Save(
		string dyingReason,
		SavannaTrees.TreeAgeGroup treeAgeGroup) {
			{
			if(!Equals(dyingReason, "RandomProbability") && !Equals(dyingReason, "PopulationDensity") && !Equals(dyingReason, "Drought")) {
							{
							System.Console.WriteLine(dyingReason);
							;}
					;} ;
			if(Equals(dyingReason, "Drought")) {
							{
							if(Equals(treeAgeGroup, TreeAgeGroup.Seed)) {
											{
											droughtSeed = droughtSeed + 1
											;}
									;} else {
											if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
															{
															droughtSeedling = droughtSeedling + 1
															;}
													;} else {
															if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																			{
																			droughtJuvenile = droughtJuvenile + 1
																			;}
																	;} else {
																			if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																							{
																							droughtAdult = droughtAdult + 1
																							;}
																					;} 
																		;}
														;}
										;}
							;}
					;} else {
							if(Equals(dyingReason, "RandomProbability")) {
											{
											if(Equals(treeAgeGroup, TreeAgeGroup.Seed)) {
															{
															randomSeed = randomSeed + 1
															;}
													;} else {
															if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
																			{
																			randomSeedling = randomSeedling + 1
																			;}
																	;} else {
																			if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																							{
																							randomJuvenile = randomJuvenile + 1
																							;}
																					;} else {
																							if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																											{
																											randomAdult = randomAdult + 1
																											;}
																									;} 
																						;}
																		;}
														;}
											;}
									;} else {
											if(Equals(dyingReason, "PopulationDensity")) {
															{
															if(Equals(treeAgeGroup, TreeAgeGroup.Seed)) {
																			{
																			populationDensitySeed = populationDensitySeed + 1
																			;}
																	;} else {
																			if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
																							{
																							populationDensitySeedling = populationDensitySeedling + 1
																							;}
																					;} else {
																							if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																											{
																											populationDensityJuvenile = populationDensityJuvenile + 1
																											;}
																									;} else {
																											if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																															{
																															populationDensityAdult = populationDensityAdult + 1
																															;}
																													;} 
																										;}
																						;}
																		;}
															;}
													;} else {
															if(Equals(dyingReason, "Dried")) {
																			{
																			if(Equals(treeAgeGroup, TreeAgeGroup.Seed)) {
																							{
																							driedSeed = driedSeed + 1
																							;}
																					;} else {
																							if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
																											{
																											driedSeedling = driedSeedling + 1
																											;}
																									;} else {
																											if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																															{
																															driedJuvenile = driedJuvenile + 1
																															;}
																													;} else {
																															if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																																			{
																																			driedAdult = driedAdult + 1
																																			;}
																																	;} 
																														;}
																										;}
																						;}
																			;}
																	;} else {
																			if(Equals(dyingReason, "Damaged")) {
																							{
																							if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
																											{
																											damagedSeedling = damagedSeedling + 1
																											;}
																									;} else {
																											if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																															{
																															damagedJuvenile = damagedJuvenile + 1
																															;}
																													;} else {
																															if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																																			{
																																			damagedAdult = damagedAdult + 1
																																			;}
																																	;} 
																														;}
																										;}
																							;}
																					;} else {
																							if(Equals(dyingReason, "Frozen")) {
																											{
																											if(Equals(treeAgeGroup, TreeAgeGroup.Seedling)) {
																															{
																															frozenSeedling = damagedSeedling + 1
																															;}
																													;} else {
																															if(Equals(treeAgeGroup, TreeAgeGroup.Juvenile)) {
																																			{
																																			frozenJuvenile = damagedJuvenile + 1
																																			;}
																																	;} else {
																																			if(Equals(treeAgeGroup, TreeAgeGroup.Adult)) {
																																							{
																																							frozenAdult = damagedAdult + 1
																																							;}
																																					;} 
																																		;}
																														;}
																											;}
																									;} 
																						;}
																		;}
														;}
										;}
						;}
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
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Rafiki (
		System.Guid _id,
		SavannaTrees.SavannaLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Rafiki> _RafikiEnvironment,
		SavannaTrees.Precipitation _Precipitation,
		SavannaTrees.Temperature _Temperature
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (xcor, ycor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			_SavannaLayer._RafikiEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
			{
			seedAcc = 0;
			growToSeedling = 0;
			droughtSeed = 0;
			droughtSeedling = 0;
			droughtJuvenile = 0;
			droughtAdult = 0;
			randomSeed = 0;
			randomSeedling = 0;
			randomJuvenile = 0;
			randomAdult = 0;
			populationDensitySeed = 0;
			populationDensitySeedling = 0;
			populationDensityJuvenile = 0;
			populationDensityAdult = 0;
			driedSeed = 0;
			driedSeedling = 0;
			driedJuvenile = 0;
			driedAdult = 0;
			damagedSeedling = 0;
			damagedJuvenile = 0;
			damagedAdult = 0;
			frozenSeedling = 0;
			frozenJuvenile = 0;
			frozenAdult = 0
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Rafiki other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
