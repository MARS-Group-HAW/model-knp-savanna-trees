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
	public class Tree : Mars.Interfaces.Environment.GeoCommon.GeoPosition, Mars.Interfaces.Agent.IMarsDslAgent {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(Tree));
		private readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private static double __growthBoosterByClimate
			 = 1.0;
		internal static double growthBoosterByClimate { 
			get { return __growthBoosterByClimate; }
			set{
				if(System.Math.Abs(__growthBoosterByClimate - value) > 0.0000001) __growthBoosterByClimate = value;
			}
		}
		private static int __SeedlingSurvivalRate
			 = default(int);
		internal static int SeedlingSurvivalRate { 
			get { return __SeedlingSurvivalRate; }
			set{
				if(__SeedlingSurvivalRate != value) __SeedlingSurvivalRate = value;
			}
		}
		private static string __AN
			 = "an";
		internal static string AN { 
			get { return __AN; }
			set{
				if(__AN != value) __AN = value;
			}
		}
		private static string __CA
			 = "ca";
		internal static string CA { 
			get { return __CA; }
			set{
				if(__CA != value) __CA = value;
			}
		}
		private static string __SB
			 = "sb";
		internal static string SB { 
			get { return __SB; }
			set{
				if(__SB != value) __SB = value;
			}
		}
		private static string __TT
			 = "tt";
		internal static string TT { 
			get { return __TT; }
			set{
				if(__TT != value) __TT = value;
			}
		}
		private static string __ALL_SPECIES
			 = "ALL";
		internal static string ALL_SPECIES { 
			get { return __ALL_SPECIES; }
			set{
				if(__ALL_SPECIES != value) __ALL_SPECIES = value;
			}
		}
		private static int __SeedSpawnRatePerYear
			 = 50;
		internal static int SeedSpawnRatePerYear { 
			get { return __SeedSpawnRatePerYear; }
			set{
				if(__SeedSpawnRatePerYear != value) __SeedSpawnRatePerYear = value;
			}
		}
		private static int __DaysPerYear
			 = 365;
		internal static int DaysPerYear { 
			get { return __DaysPerYear; }
			set{
				if(__DaysPerYear != value) __DaysPerYear = value;
			}
		}
		private static int __DaysWithLeaves
			 = 228;
		internal static int DaysWithLeaves { 
			get { return __DaysWithLeaves; }
			set{
				if(__DaysWithLeaves != value) __DaysWithLeaves = value;
			}
		}
		private static double __E
			 = 2.718281828459045;
		internal static double E { 
			get { return __E; }
			set{
				if(System.Math.Abs(__E - value) > 0.0000001) __E = value;
			}
		}
		private static double __PI
			 = 3.14159265359;
		internal static double PI { 
			get { return __PI; }
			set{
				if(System.Math.Abs(__PI - value) > 0.0000001) __PI = value;
			}
		}
		private static double __EarthRadiusInMeters
			 = 6378100.0;
		internal static double EarthRadiusInMeters { 
			get { return __EarthRadiusInMeters; }
			set{
				if(System.Math.Abs(__EarthRadiusInMeters - value) > 0.0000001) __EarthRadiusInMeters = value;
			}
		}
		private bool __IsScenario45not85
			 = default(bool);
		internal bool IsScenario45not85 { 
			get { return __IsScenario45not85; }
			set{
				if(__IsScenario45not85 != value) __IsScenario45not85 = value;
			}
		}
		private string __Species
			 = default(string);
		public string Species { 
			get { return __Species; }
			set{
				if(__Species != value) __Species = value;
			}
		}
		private double __StemDiameter
			 = default(double);
		public double StemDiameter { 
			get { return __StemDiameter; }
			set{
				if(System.Math.Abs(__StemDiameter - value) > 0.0000001) __StemDiameter = value;
			}
		}
		private string __Raster
			 = default(string);
		public string Raster { 
			get { return __Raster; }
			set{
				if(__Raster != value) __Raster = value;
			}
		}
		private SavannaTrees.TreeAgeGroup __MyTreeAgeGroup
			 = default(SavannaTrees.TreeAgeGroup);
		public SavannaTrees.TreeAgeGroup MyTreeAgeGroup { 
			get { return __MyTreeAgeGroup; }
			set{
				if(__MyTreeAgeGroup != value) __MyTreeAgeGroup = value;
			}
		}
		private double __LivingWoodMass
			 = default(double);
		public double LivingWoodMass { 
			get { return __LivingWoodMass; }
			set{
				if(System.Math.Abs(__LivingWoodMass - value) > 0.0000001) __LivingWoodMass = value;
			}
		}
		private double __DeadWoodMass
			 = default(double);
		public double DeadWoodMass { 
			get { return __DeadWoodMass; }
			set{
				if(System.Math.Abs(__DeadWoodMass - value) > 0.0000001) __DeadWoodMass = value;
			}
		}
		private double __Bark
			 = default(double);
		public double Bark { 
			get { return __Bark; }
			set{
				if(System.Math.Abs(__Bark - value) > 0.0000001) __Bark = value;
			}
		}
		private string __DyingReason
			 = default(string);
		public string DyingReason { 
			get { return __DyingReason; }
			set{
				if(__DyingReason != value) __DyingReason = value;
			}
		}
		private SavannaTrees.DamageType __MyDamageType
			 = default(SavannaTrees.DamageType);
		public SavannaTrees.DamageType MyDamageType { 
			get { return __MyDamageType; }
			set{
				if(__MyDamageType != value) __MyDamageType = value;
			}
		}
		private int __InitializeYear
			 = default(int);
		public int InitializeYear { 
			get { return __InitializeYear; }
			set{
				if(__InitializeYear != value) __InitializeYear = value;
			}
		}
		private bool __HasLeaves
			 = default(bool);
		internal bool HasLeaves { 
			get { return __HasLeaves; }
			set{
				if(__HasLeaves != value) __HasLeaves = value;
			}
		}
		private double __FirstDayAsSeedling
			 = default(double);
		internal double FirstDayAsSeedling { 
			get { return __FirstDayAsSeedling; }
			set{
				if(System.Math.Abs(__FirstDayAsSeedling - value) > 0.0000001) __FirstDayAsSeedling = value;
			}
		}
		private bool __seedSurvivedFirst12Days
			 = default(bool);
		internal bool seedSurvivedFirst12Days { 
			get { return __seedSurvivedFirst12Days; }
			set{
				if(__seedSurvivedFirst12Days != value) __seedSurvivedFirst12Days = value;
			}
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> TreePosition() 
		{
			{
			return new System.Tuple<double,double>(base.Position[0],base.Position[1])
					;
			}
			return default(System.Tuple<double,double>);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void ReduceBarkBy(double subtrahend) 
		{
			{
			Bark = Bark - subtrahend
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateOnNewBark() 
		{
			{
			if(Bark < 0) {
							{
							this.Die("RoundBarked")
							;}
					;} else {
							if(Bark < 0.5) {
											{
											MyDamageType = DamageType.Moderate
											;}
									;} 
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double ReduceLivingWoodMassBy(double mass) 
		{
			{
			double currentLivingWoodMass = CalculateLivingWoodMassByDiameter();
			double result = default(double);;
			if(mass < currentLivingWoodMass) {
							{
							result = mass
							;}
					;} else {
							{
							result = currentLivingWoodMass
							;}
						;};
			MyDamageType = CalculateDamageType(result);
			SavannaTrees.Rafiki rafiki = new Func<SavannaTrees.Rafiki>(() => {
			Func<SavannaTrees.Rafiki, bool> _predicate141_3169 = null;
			Func<SavannaTrees.Rafiki, bool> _predicateMod141_3169 = new Func<SavannaTrees.Rafiki, bool>(_it => 
			{
				if (_it?.ID == this.ID)
				{
					return false;
				} else if (_predicate141_3169 != null)
				{
					return _predicate141_3169.Invoke(_it);
				} else return true;
			});
			
			
			const int _range141_3169 = -1;
			var _source141_3169 = this;
			return _SavannaLayer._RafikiEnvironment.Explore(
			_source141_3169.Position, _range141_3169, 1, _predicateMod141_3169)?.FirstOrDefault();}).Invoke();
			rafiki.SaveDamageType(MyDamageType);
			LivingWoodMass = LivingWoodMass - result;
			StemDiameter = CalculateDiameterByWoodMass();
			return result
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public SavannaTrees.DamageType CalculateDamageType(double result) 
		{
			{
			double quota = result / LivingWoodMass;
			if(quota > 0.8) {
							{
							return DamageType.Extreme
							;}
					;} else {
							if(quota > 0.6) {
											{
											return DamageType.Heavy
											;}
									;} else {
											if(quota > 0.3) {
															{
															return DamageType.Moderate
															;}
													;} else {
															if(quota > 0.1) {
																			{
																			return DamageType.Light
																			;}
																	;} 
														;}
										;}
						;};
			return DamageType.No
			;}
			return default(SavannaTrees.DamageType);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void ReduceStemDiameterBy(double percent) 
		{
			{
			StemDiameter = StemDiameter - StemDiameter * percent / 100
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdatePhotosyntheseActive() 
		{
			{
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 10) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							HasLeaves = true
					;} else {
							if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
							, 6) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
							, 15)) {
											HasLeaves = false
									;} 
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateTreeAgeGroup() 
		{
			{
			if(StemDiameter >= 1) {
							{
							if(IsJuvenileByStemDiameter()) {
											{
											MyTreeAgeGroup = TreeAgeGroup.Juvenile
											;}
									;} else {
											{
											MyTreeAgeGroup = TreeAgeGroup.Adult
											;}
										;}
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsJuvenileByStemDiameter() 
		{
			{
			string _switch203_4772 = (Species);
			bool _matched_203_4772 = false;
			bool _fallthrough_203_4772 = false;
			if(!_matched_203_4772 || _fallthrough_203_4772) {
				if(Equals(_switch203_4772, AN)) {
					_matched_203_4772 = true;
					{
					return StemDiameter < 8
					;}
				} else {
					_fallthrough_203_4772 = false;
				}
			}
			if(!_matched_203_4772 || _fallthrough_203_4772) {
				if(Equals(_switch203_4772, CA)) {
					_matched_203_4772 = true;
					{
					return StemDiameter < 10
					;}
				} else {
					_fallthrough_203_4772 = false;
				}
			}
			if(!_matched_203_4772 || _fallthrough_203_4772) {
				if(Equals(_switch203_4772, SB)) {
					_matched_203_4772 = true;
					{
					return StemDiameter < 20
					;}
				} else {
					_fallthrough_203_4772 = false;
				}
			}
			if(!_matched_203_4772 || _fallthrough_203_4772) {
				if(Equals(_switch203_4772, TT)) {
					_matched_203_4772 = true;
					{
					return StemDiameter < 13
					;}
				} else {
					_fallthrough_203_4772 = false;
				}
			}
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seed() 
		{
			{
			if(HasPrecipitation()) {
							{
							SavannaTrees.Rafiki rafiki = new Func<SavannaTrees.Rafiki>(() => {
							Func<SavannaTrees.Rafiki, bool> _predicate235_5483 = null;
							Func<SavannaTrees.Rafiki, bool> _predicateMod235_5483 = new Func<SavannaTrees.Rafiki, bool>(_it => 
							{
								if (_it?.ID == this.ID)
								{
									return false;
								} else if (_predicate235_5483 != null)
								{
									return _predicate235_5483.Invoke(_it);
								} else return true;
							});
							
							
							const int _range235_5483 = -1;
							var _source235_5483 = this;
							return _SavannaLayer._RafikiEnvironment.Explore(
							_source235_5483.Position, _range235_5483, 1, _predicateMod235_5483)?.FirstOrDefault();}).Invoke();
							rafiki.Save("SpawnedSeeds");
							if(RandomProbabilitySmallenThan(100 - SeedlingSurvivalRate + _Random.Next(SeedlingSurvivalRate))) {
											{
											this.Die("RandomProbability")
											;}
									;} else {
											if(IsPopulationDensityExceeded()) {
															{
															this.Die("PopulationDensity")
															;}
													;} else {
															{
															rafiki.Save("GrowedToSeedling");
															FirstDayAsSeedling = Mars.Components.Common.Time.TotalDays((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep);
															MyTreeAgeGroup = TreeAgeGroup.Seedling
															;}
														;}
										;}
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Seedling() 
		{
			{
			if(IsFrozen()) {
							{
							this.Die("Frozen")
							;}
					;} else {
							if(IsDried()) {
											{
											this.Die("Dried")
											;}
									;} else {
											if(!Equals(MyDamageType, DamageType.No)) {
															{
															this.Die("Damaged")
															;}
													;} else {
															if(HasLeaves) {
																			{
																			GrowSeedling()
																			;}
																	;} 
														;}
										;}
						;}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsFrozen() 
		{
			{
			if(Equals(Species, AN)) {
							return false
					;} ;
			double tempToday = temperature.GetNumberValue(base.Position[0],base.Position[1]);
			return tempToday < 0 && RandomProbabilitySmallenThan(80)
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsDried() 
		{
			{
			if(FirstDayAsSeedling + 12 > Mars.Components.Common.Time.TotalDays((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			) {
							{
							seedSurvivedFirst12Days = HasPrecipitation() || seedSurvivedFirst12Days;
							return false
							;}
					;} ;
			return !seedSurvivedFirst12Days
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool HasPrecipitation() 
		{
			{
			double precipitationToday = precipitation.GetNumberValue(base.Position[0],base.Position[1]);
			return precipitationToday > 1
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Juvenile() 
		{
			{
			if(HasLeaves) {
							{
							if(!Equals(MyDamageType, DamageType.No)) {
											{
											GrowResprouting()
											;}
									;} else {
											{
											GrowJuvenile()
											;}
										;}
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Adult() 
		{
			{
			if(HasLeaves) {
							{
							if(Equals(MyDamageType, DamageType.No)) {
											{
											GrowAdult(1)
											;}
									;} else {
											if(Equals(MyDamageType, DamageType.Light)) {
															{
															GrowAdult(ReducedTo(90,100))
															;}
													;} else {
															if(Equals(MyDamageType, DamageType.Moderate)) {
																			{
																			GrowAdult(ReducedTo(70,90))
																			;}
																	;} else {
																			if(Equals(MyDamageType, DamageType.Heavy)) {
																							{
																							GrowAdult(ReducedTo(40,70))
																							;}
																					;} else {
																							if(Equals(MyDamageType, DamageType.Extreme)) {
																											{
																											GrowResprouting()
																											;}
																									;} 
																						;}
																		;}
														;}
										;}
							;}
					;} ;
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 3) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							{
							SpawnSeeds()
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SpawnSeeds() 
		{
			{
			for(int i = 0;
					 i < SeedSpawnRatePerYear;
					 i++){
					 	{
					 	SavannaTrees.Tree seed = new System.Func<SavannaTrees.Tree>(() => {
					 	var _target314_7436 = GetRelativePosition(base.Position[1],base.Position[0],_Random.Next(360),_Random.Next(50));
					 	return _SavannaLayer._SpawnTree(_target314_7436.Item1, _target314_7436.Item2);}).Invoke();
					 	seed.SetSpecies(Species);
					 	int raster = treeRaster.GetIntegerValue(seed.Xcor(),
					 	seed.Ycor()
					 	);
					 	if(raster > 0) {
					 					{
					 					seed.SetRaster(raster + "")
					 					;}
					 			;} else {
					 					{
					 					seed.Die("DeathZone")
					 					;}
					 				;}
					 	;}
					 }
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowSeedling() 
		{
			{
			StemDiameter = StemDiameter + 1d / DaysWithLeaves
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowResprouting() 
		{
			{
			GrowJuvenile()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenile() 
		{
			{
			string _switch347_8083 = (Species);
			bool _matched_347_8083 = false;
			bool _fallthrough_347_8083 = false;
			if(!_matched_347_8083 || _fallthrough_347_8083) {
				if(Equals(_switch347_8083, AN)) {
					_matched_347_8083 = true;
					{
					GrowJuvenileAn()
					;}
				} else {
					_fallthrough_347_8083 = false;
				}
			}
			if(!_matched_347_8083 || _fallthrough_347_8083) {
				if(Equals(_switch347_8083, CA)) {
					_matched_347_8083 = true;
					{
					GrowJuvenileCa()
					;}
				} else {
					_fallthrough_347_8083 = false;
				}
			}
			if(!_matched_347_8083 || _fallthrough_347_8083) {
				if(Equals(_switch347_8083, SB)) {
					_matched_347_8083 = true;
					{
					GrowJuvenileSb()
					;}
				} else {
					_fallthrough_347_8083 = false;
				}
			}
			if(!_matched_347_8083 || _fallthrough_347_8083) {
				if(Equals(_switch347_8083, TT)) {
					_matched_347_8083 = true;
					{
					GrowJuvenileTt()
					;}
				} else {
					_fallthrough_347_8083 = false;
				}
			}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileAn() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 0.9) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileCa() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.2) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileSb() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.9) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowJuvenileTt() 
		{
			{
			StemDiameter = StemDiameter + (-0.068 * StemDiameter + 1.33) / DaysWithLeaves * growthBoosterByClimate
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdult(double reduceFactor) 
		{
			{
			string _switch372_8810 = (Species);
			bool _matched_372_8810 = false;
			bool _fallthrough_372_8810 = false;
			if(!_matched_372_8810 || _fallthrough_372_8810) {
				if(Equals(_switch372_8810, AN)) {
					_matched_372_8810 = true;
					{
					GrowAdultAn(reduceFactor)
					;}
				} else {
					_fallthrough_372_8810 = false;
				}
			}
			if(!_matched_372_8810 || _fallthrough_372_8810) {
				if(Equals(_switch372_8810, CA)) {
					_matched_372_8810 = true;
					{
					GrowAdultCa(reduceFactor)
					;}
				} else {
					_fallthrough_372_8810 = false;
				}
			}
			if(!_matched_372_8810 || _fallthrough_372_8810) {
				if(Equals(_switch372_8810, SB)) {
					_matched_372_8810 = true;
					{
					GrowAdultSb(reduceFactor)
					;}
				} else {
					_fallthrough_372_8810 = false;
				}
			}
			if(!_matched_372_8810 || _fallthrough_372_8810) {
				if(Equals(_switch372_8810, TT)) {
					_matched_372_8810 = true;
					{
					GrowAdultTt(reduceFactor)
					;}
				} else {
					_fallthrough_372_8810 = false;
				}
			}
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultAn(double reduceFactor) 
		{
			{
			int maxStemDiameter = 20;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultCa(double reduceFactor) 
		{
			{
			int maxStemDiameter = 20;
			double growthRate = 0.5;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultSb(double reduceFactor) 
		{
			{
			int maxStemDiameter = 50;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void GrowAdultTt(double reduceFactor) 
		{
			{
			int maxStemDiameter = 30;
			int growthRate = 1;
			StemDiameter = StemDiameter + StemDiameterGrowthForAdult(maxStemDiameter,growthRate,reduceFactor)
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsPopulationDensityExceeded() 
		{
			{
			return IsTooCloseTo(TreeAgeGroup.Seed,ALL_SPECIES,0.04) || IsTooCloseTo(TreeAgeGroup.Seedling,ALL_SPECIES,0.04) || IsTooCloseTo(TreeAgeGroup.Juvenile,AN,0.32) || IsTooCloseTo(TreeAgeGroup.Juvenile,CA,0.40) || IsTooCloseTo(TreeAgeGroup.Juvenile,SB,0.80) || IsTooCloseTo(TreeAgeGroup.Juvenile,TT,0.52) || IsTooCloseTo(TreeAgeGroup.Adult,AN,0.80) || IsTooCloseTo(TreeAgeGroup.Adult,CA,0.80) || IsTooCloseTo(TreeAgeGroup.Adult,SB,2.00) || IsTooCloseTo(TreeAgeGroup.Adult,TT,1.20)
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsTooCloseTo(SavannaTrees.TreeAgeGroup treeAgeGroup, string species, double minDistance) 
		{
			{
			SavannaTrees.Tree tree = new Func<SavannaTrees.Tree>(() => {
			Func<SavannaTrees.Tree, bool> _predicate418_10478 = new Func<SavannaTrees.Tree,bool>((SavannaTrees.Tree x) => 
			 {
					{
					return !Equals(x, this) && x.IsTreeAgeGroup(treeAgeGroup)
					 && x.IsSpecies(species)
					;}
					;
					return default(bool);;
			});
			Func<SavannaTrees.Tree, bool> _predicateMod418_10478 = new Func<SavannaTrees.Tree, bool>(_it => 
			{
				if (_it?.ID == this.ID)
				{
					return false;
				} else if (_predicate418_10478 != null)
				{
					return _predicate418_10478.Invoke(_it);
				} else return true;
			});
			
			
			const int _range418_10478 = -1;
			var _source418_10478 = this;
			return _SavannaLayer._TreeEnvironment.Explore(
			_source418_10478, _range418_10478, 1, _predicateMod418_10478)?.FirstOrDefault();}).Invoke();
			return !Equals(tree, null) && DistanceTo(tree) < minDistance
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double DistanceTo(SavannaTrees.Tree tree) 
		{
			{
			double constant = 111.3;
			double lat = (tree.Ycor()
			 + base.Position[1]) / 2 * 0.01745;
			double dx = constant * Mars.Components.Common.Math.Cos(lat)
			 * (tree.Xcor()
			 - base.Position[0]);
			double dy = constant * (tree.Ycor()
			 - base.Position[1]);
			return 1000 * Mars.Components.Common.Math.Sqrt(dx * dx + dy * dy)
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double StemDiameterGrowthForAdult(double maxStemDiameter, double growthRate, double reduceFactor) 
		{
			{
			return (1 - StemDiameter / maxStemDiameter) * growthRate / DaysWithLeaves * reduceFactor * growthBoosterByClimate
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateLivingWoodMassByDiameter() 
		{
			{
			if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seed) || Equals(MyTreeAgeGroup, TreeAgeGroup.Seedling)) {
							{
							return 0
							;}
					;} ;
			string _switch438_11304 = (Species);
			bool _matched_438_11304 = false;
			bool _fallthrough_438_11304 = false;
			if(!_matched_438_11304 || _fallthrough_438_11304) {
				if(Equals(_switch438_11304, AN)) {
					_matched_438_11304 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.55 + 3.060 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_438_11304 = false;
				}
			}
			if(!_matched_438_11304 || _fallthrough_438_11304) {
				if(Equals(_switch438_11304, CA)) {
					_matched_438_11304 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.27 + 2.800 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_438_11304 = false;
				}
			}
			if(!_matched_438_11304 || _fallthrough_438_11304) {
				if(Equals(_switch438_11304, SB)) {
					_matched_438_11304 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.35 + 2.620 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_438_11304 = false;
				}
			}
			if(!_matched_438_11304 || _fallthrough_438_11304) {
				if(Equals(_switch438_11304, TT)) {
					_matched_438_11304 = true;
					{
					return Mars.Components.Common.Math.Pow(E, (-3.39 + 2.827 * Mars.Components.Common.Math.Log(StemDiameter)
					)) / 0.6
					;}
				} else {
					_fallthrough_438_11304 = false;
				}
			}
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double CalculateDiameterByWoodMass() 
		{
			{
			string _switch447_11686 = (Species);
			bool _matched_447_11686 = false;
			bool _fallthrough_447_11686 = false;
			if(!_matched_447_11686 || _fallthrough_447_11686) {
				if(Equals(_switch447_11686, AN)) {
					_matched_447_11686 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.55 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 3.060))
					;}
				} else {
					_fallthrough_447_11686 = false;
				}
			}
			if(!_matched_447_11686 || _fallthrough_447_11686) {
				if(Equals(_switch447_11686, CA)) {
					_matched_447_11686 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.27 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.800))
					;}
				} else {
					_fallthrough_447_11686 = false;
				}
			}
			if(!_matched_447_11686 || _fallthrough_447_11686) {
				if(Equals(_switch447_11686, SB)) {
					_matched_447_11686 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.35 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.620))
					;}
				} else {
					_fallthrough_447_11686 = false;
				}
			}
			if(!_matched_447_11686 || _fallthrough_447_11686) {
				if(Equals(_switch447_11686, TT)) {
					_matched_447_11686 = true;
					{
					return Mars.Components.Common.Math.Pow(E, ((3.39 + Mars.Components.Common.Math.Log(LivingWoodMass * 0.6)
					) / 2.827))
					;}
				} else {
					_fallthrough_447_11686 = false;
				}
			}
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double GenerateDeadwoodMass() 
		{
			{
			return 0.017 * LivingWoodMass / DaysPerYear
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void ResetDamageType() 
		{
			{
			MyDamageType = DamageType.No
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void ResetBarkBy(double percent) 
		{
			{
			Bark = Bark + Bark * percent / 100.0;
			if(Bark > 1.0) {
							{
							Bark = 1.0
							;}
					;} 
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void InitWoodMass() 
		{
			{
			LivingWoodMass = CalculateLivingWoodMassByDiameter();
			DeadWoodMass = 0.017 * LivingWoodMass
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void UpdateWoodMass() 
		{
			{
			LivingWoodMass = CalculateLivingWoodMassByDiameter();
			DeadWoodMass = DeadWoodMass + GenerateDeadwoodMass()
			;}
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double Reduce(double growthrate, int min, int max) 
		{
			{
			return growthrate * (min + RandomBetween(min,max)) / 100
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool RandomProbabilitySmallenThan(int percentage) 
		{
			{
			return _Random.Next(100) < percentage
			;}
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double RandomBetween(int min, int max) 
		{
			{
			return _Random.Next(max + 1 - min) + min
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double ReducedTo(int minPercentage, int maxPercentag) 
		{
			{
			return RandomBetween(minPercentage,maxPercentag) / 100
			;}
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public System.Tuple<double,double> GetRelativePosition(double originLongitude, double originLatitude, double bearing, double distanceInM) 
		{
			{
			double DegreesToRadians = PI / 180.0;
			double RadiansToDegrees = 180.0 / PI;
			double latA = DegreesToRadians * originLatitude;
			double lonA = originLongitude * DegreesToRadians;
			double radBearing = bearing * DegreesToRadians;
			double cosB = Mars.Components.Common.Math.Cos(distanceInM / EarthRadiusInMeters);
			double cosLatB = Mars.Components.Common.Math.Cos(latA);
			double SinLatA = Mars.Components.Common.Math.Sin(latA);
			double sinB = Mars.Components.Common.Math.Sin(distanceInM / EarthRadiusInMeters);
			double cosBearing = Mars.Components.Common.Math.Cos(radBearing);
			double temp1 = SinLatA * cosB;
			double temp2 = 0;
			double lat = Mars.Components.Common.Math.Asin(temp1 + cosLatB * sinB * cosBearing);
			double SinLat = Mars.Components.Common.Math.Sin(lat);
			double sindBearing = Mars.Components.Common.Math.Sin(radBearing);
			double atan1 = sindBearing * Mars.Components.Common.Math.Sin(distanceInM / EarthRadiusInMeters)
			 * Mars.Components.Common.Math.Cos(latA);
			double cosDistance = Mars.Components.Common.Math.Cos(distanceInM / EarthRadiusInMeters);
			double atan2 = cosDistance - SinLatA * SinLat;
			double lon = lonA + Mars.Components.Common.Math.Atan2(atan1,atan2);
			double latResult = lat * RadiansToDegrees;
			double lonResult = lon * RadiansToDegrees;
			return new System.Tuple<double,double>(lonResult,latResult)
			;}
			return default(System.Tuple<double,double>);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double Xcor() {
			{
			return base.Position[0]
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double Ycor() {
			{
			return base.Position[1]
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsTreeAgeGroup(
		SavannaTrees.TreeAgeGroup treeAgeGroup) {
			{
			return Equals(MyTreeAgeGroup, treeAgeGroup)
			;}
			
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public bool IsSpecies(
		string species) {
			{
			return Equals(species, ALL_SPECIES) || Equals(Species, species)
			;}
			
			return default(bool);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void TakeBark(
		double percent) {
			{
			ReduceBarkBy(percent / 100);
			UpdateOnNewBark()
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDeadWoodMass(
		double mass) {
			{
			double result = default(double);;
			if(mass < DeadWoodMass) {
							{
							result = mass
							;}
					;} else {
							{
							result = DeadWoodMass
							;}
						;};
			DeadWoodMass = DeadWoodMass - result;
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakePushOver() {
			{
			double result = ReduceLivingWoodMassBy(LivingWoodMass);
			if(RandomProbabilitySmallenThan(50)) {
							{
							this.Die("PushOver")
							;}
					;} ;
			return result
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeDamage(
		double mass) {
			{
			return ReduceLivingWoodMassBy(mass)
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public double TakeLivingWoodMass(
		double mass) {
			{
			return ReduceLivingWoodMassBy(mass)
			;}
			
			return default(double);;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SufferDrought() {
			{
			if(!Equals(MyTreeAgeGroup, TreeAgeGroup.Adult) && RandomProbabilitySmallenThan(7)) {
							{
							this.Die("Drought")
							;}
					;} 
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SufferHerbivorePressure() {
			{
			if(RandomProbabilitySmallenThan(30) && (Equals(MyTreeAgeGroup, TreeAgeGroup.Juvenile) || Equals(MyTreeAgeGroup, TreeAgeGroup.Adult))) {
							{
							string _switch172_3982 = (Species);
							bool _matched_172_3982 = false;
							bool _fallthrough_172_3982 = false;
							if(!_matched_172_3982 || _fallthrough_172_3982) {
								if(Equals(_switch172_3982, AN)) {
									_matched_172_3982 = true;
									{
									ReduceStemDiameterBy(4)
									;}
								} else {
									_fallthrough_172_3982 = false;
								}
							}
							if(!_matched_172_3982 || _fallthrough_172_3982) {
								if(Equals(_switch172_3982, CA)) {
									_matched_172_3982 = true;
									{
									ReduceStemDiameterBy(1)
									;}
								} else {
									_fallthrough_172_3982 = false;
								}
							}
							if(!_matched_172_3982 || _fallthrough_172_3982) {
								if(Equals(_switch172_3982, SB)) {
									_matched_172_3982 = true;
									{
									ReduceStemDiameterBy(6)
									;}
								} else {
									_fallthrough_172_3982 = false;
								}
							}
							if(!_matched_172_3982 || _fallthrough_172_3982) {
								if(Equals(_switch172_3982, TT)) {
									_matched_172_3982 = true;
									{
									ReduceStemDiameterBy(4)
									;}
								} else {
									_fallthrough_172_3982 = false;
								}
							}
							;}
					;} 
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetSpecies(
		string species) {
			{
			Species = species
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetTreeAgeGroup(
		SavannaTrees.TreeAgeGroup treeAgeGroup) {
			{
			MyTreeAgeGroup = treeAgeGroup
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void SetRaster(
		string raster) {
			{
			Raster = raster
			;}
			
			return;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void Die(
		string reason) {
			{
			DyingReason = reason;
			SavannaTrees.Rafiki rafiki = new Func<SavannaTrees.Rafiki>(() => {
			Func<SavannaTrees.Rafiki, bool> _predicate461_12177 = null;
			Func<SavannaTrees.Rafiki, bool> _predicateMod461_12177 = new Func<SavannaTrees.Rafiki, bool>(_it => 
			{
				if (_it?.ID == this.ID)
				{
					return false;
				} else if (_predicate461_12177 != null)
				{
					return _predicate461_12177.Invoke(_it);
				} else return true;
			});
			
			
			const int _range461_12177 = -1;
			var _source461_12177 = this;
			return _SavannaLayer._RafikiEnvironment.Explore(
			_source461_12177.Position, _range461_12177, 1, _predicateMod461_12177)?.FirstOrDefault();}).Invoke();
			rafiki.SaveDyingReason(reason,MyTreeAgeGroup);
			MyTreeAgeGroup = TreeAgeGroup.Death;
			new System.Action(() => {
				var _target464_12283 = this;
				if (_target464_12283 != null) {
					_SavannaLayer._KillTree(_target464_12283, _target464_12283._executionFrequency);
				}
			}).Invoke()
			;}
			
			return;
		}
		internal bool _isAlive;
		internal int _executionFrequency;
		
		public SavannaTrees.SavannaLayer _Layer_ => _SavannaLayer;
		public SavannaTrees.SavannaLayer _SavannaLayer { get; set; }
		public Mars.Components.Environments.GeoGridHashEnvironment<Rafiki> _RafikiEnvironment { get; set; }
		public Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment { get; set; }
		public SavannaTrees.Precipitation _Precipitation { get; set; }
		public SavannaTrees.Precipitation precipitation => _Precipitation;
		public SavannaTrees.Temperature _Temperature { get; set; }
		public SavannaTrees.Temperature temperature => _Temperature;
		public SavannaTrees.TreeRaster _TreeRaster { get; set; }
		public SavannaTrees.TreeRaster treeRaster => _TreeRaster;
		
		[Mars.Interfaces.LIFECapabilities.PublishForMappingInMars]
		public Tree (
		System.Guid _id,
		SavannaTrees.SavannaLayer _layer,
		Mars.Interfaces.Layer.RegisterAgent _register,
		Mars.Interfaces.Layer.UnregisterAgent _unregister,
		Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment,
		SavannaTrees.Precipitation _Precipitation,
		SavannaTrees.Temperature _Temperature,
		SavannaTrees.TreeRaster _TreeRaster
	,	bool IsScenario45not85,
		string Species,
		double StemDiameter,
		string Raster
	,	double xcor = 0, double ycor = 0, int freq = 1)
		 : base (ycor, xcor)
		{
			_SavannaLayer = _layer;
			ID = _id;
			this.IsScenario45not85 = IsScenario45not85;
			this.Species = Species;
			this.StemDiameter = StemDiameter;
			this.Raster = Raster;
			this._Precipitation = _Precipitation;
			this._Temperature = _Temperature;
			this._TreeRaster = _TreeRaster;
			_SavannaLayer._TreeEnvironment.Insert(this);
			_register(_layer, this, freq);
			_isAlive = true;
			_executionFrequency = freq;
			{
			MyTreeAgeGroup = TreeAgeGroup.Seed;
			MyDamageType = DamageType.No;
			Bark = 1.0;
			UpdateTreeAgeGroup();
			InitWoodMass();
			if(IsScenario45not85) {
							{
							SeedlingSurvivalRate = 12;
							growthBoosterByClimate = 1.0
							;}
					;} else {
							{
							SeedlingSurvivalRate = 15;
							growthBoosterByClimate = 1.3
							;}
						;};
			InitializeYear = Mars.Components.Common.Time.Year((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			;}
		}
		
		public void Tick()
		{
			{ if (!_isAlive) return; }
			{
			UpdateTreeAgeGroup();
			UpdatePhotosyntheseActive();
			if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seed)) {
							{
							Seed()
							;}
					;} else {
							if(Equals(MyTreeAgeGroup, TreeAgeGroup.Seedling)) {
											{
											Seedling()
											;}
									;} else {
											if(Equals(MyTreeAgeGroup, TreeAgeGroup.Juvenile)) {
															{
															Juvenile()
															;}
													;} else {
															if(Equals(MyTreeAgeGroup, TreeAgeGroup.Adult)) {
																			{
																			Adult()
																			;}
																	;} 
														;}
										;}
						;};
			UpdateWoodMass();
			if(Equals(Mars.Components.Common.Time.Month((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 3) && Equals(Mars.Components.Common.Time.Day((int) Mars.Core.SimulationManager.Entities.SimulationClock.CurrentStep)
			, 15)) {
							{
							ResetDamageType();
							ResetBarkBy(30)
							;}
					;} 
			;}
		}
		
		public System.Guid ID { get; }
		public bool Equals(Tree other) => Equals(ID, other.ID);
		public override int GetHashCode() => ID.GetHashCode();
	}
}
