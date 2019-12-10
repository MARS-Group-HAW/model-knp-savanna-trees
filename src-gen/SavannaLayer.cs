namespace SavannaTrees {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	// Pragma and ReSharper disable all warnings for generated code
	#pragma warning disable 162
	#pragma warning disable 219
	#pragma warning disable 169
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "InconsistentNaming")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantNameQualifier")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "MemberInitializerValueIgnored")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantCheckBeforeAssignment")]
	public class SavannaLayer : Mars.Components.Layers.AbstractLayer {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(SavannaLayer));
		private readonly System.Random _Random = new System.Random();
		public Mars.Interfaces.Layer.UnregisterAgent _Unregister { get; set; }
		public Mars.Interfaces.Layer.RegisterAgent _Register { get; set; }
		public Mars.Mathematics.SpaceDistanceMetric _DistanceMetric { get; set; } = Mars.Mathematics.SpaceDistanceMetric.Euclidean;
		private double _minLon;
		private double _minLat;
		private double _maxLon;
		private double _maxLat;
		private bool _isDefault;
		private int? _cellSizeMeters;
		private Mars.Interfaces.Environment.Position _lowerLeft;
		private Mars.Interfaces.Environment.Position _upperRight;
		private Mars.Interfaces.Environment.Position _lowerRight;
		private Mars.Interfaces.Environment.Position _upperLeft;
		public double MinLon() => _minLon;
		public double MinLat() => _minLat;
		public double MaxLon() => _maxLon;
		public double MaxLat() => _maxLat;
		
		public Mars.Components.Environments.GeoHashEnvironment<Rafiki> _RafikiEnvironment { get; set; }
		public Mars.Components.Environments.GeoHashEnvironment<Tree> _TreeEnvironment { get; set; }
		public Precipitation _Precipitation { get; set; }
		public Temperature _Temperature { get; set; }
		public TreeRaster _TreeRaster { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Rafiki> _RafikiAgents { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Tree> _TreeAgents { get; set; }
		
		public SavannaLayer _SavannaLayer => this;
		public SavannaLayer (
		Precipitation _precipitation, Temperature _temperature, TreeRaster _treeraster, 
		double? minLon = null, double? minLat = null,
		double? maxLon = null, double? maxLat = null,
		int? cellSizeMeters = null
		) {
			this._Precipitation = _precipitation;
			this._Temperature = _temperature;
			this._TreeRaster = _treeraster;
			_minLon = minLon ?? 0;
			_minLat = minLat ?? 0;
			_maxLon = maxLon ?? 1;
			_maxLat = maxLat ?? 1;
			_cellSizeMeters = cellSizeMeters;
			_isDefault = (minLon == null && minLat == null && maxLon == null && maxLat == null);
			_lowerLeft = Mars.Interfaces.Environment.Position.CreateGeoPosition(_minLon, _minLat);
			_upperRight = Mars.Interfaces.Environment.Position.CreateGeoPosition(_maxLon, _maxLat);
			_upperLeft = Mars.Interfaces.Environment.Position.CreateGeoPosition(_minLon, _maxLat);
			_lowerRight = Mars.Interfaces.Environment.Position.CreateGeoPosition(_maxLon, _minLat);
		}
		
		public override bool InitLayer(
			Mars.Interfaces.Layer.Initialization.TInitData initData, 
			Mars.Interfaces.Layer.RegisterAgent regHandle, 
			Mars.Interfaces.Layer.UnregisterAgent unregHandle)
		{
			base.InitLayer(initData, regHandle, unregHandle);
			this._Register = regHandle;
			this._Unregister = unregHandle;
			
			_DistanceMetric = Mars.Mathematics.SpaceDistanceMetric.Chebyshev;
			var _gisLayerExist = true;
			if (!_isDefault && _lowerLeft != null && _upperRight != null) {
				this._RafikiEnvironment = Mars.Components.Environments.GeoHashEnvironment<Rafiki>.BuildByBBox(_lowerLeft.Longitude, _lowerLeft.Latitude, _upperRight.Longitude, _upperRight.Latitude);
				this._TreeEnvironment = Mars.Components.Environments.GeoHashEnvironment<Tree>.BuildByBBox(_lowerLeft.Longitude, _lowerLeft.Latitude, _upperRight.Longitude, _upperRight.Latitude);
			} else if (_gisLayerExist)
			{
				var geometries = new List<GeoAPI.Geometries.IGeometry>();
				var _factory = new NetTopologySuite.Utilities.GeometricShapeFactory();
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._Precipitation.LowerLeft.Longitude, this._Precipitation.LowerLeft.Latitude);
				_factory.Height = this._Precipitation.CellHeight * this._Precipitation.Height;
				_factory.Width = this._Precipitation.CellWidth * this._Precipitation.Width;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._Temperature.LowerLeft.Longitude, this._Temperature.LowerLeft.Latitude);
				_factory.Height = this._Temperature.CellHeight * this._Temperature.Height;
				_factory.Width = this._Temperature.CellWidth * this._Temperature.Width;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._TreeRaster.LowerLeft.Longitude, this._TreeRaster.LowerLeft.Latitude);
				_factory.Height = this._TreeRaster.CellHeight * this._TreeRaster.Height;
				_factory.Width = this._TreeRaster.CellWidth * this._TreeRaster.Width;
				geometries.Add(_factory.CreateRectangle());
				var _feature = new NetTopologySuite.Geometries.GeometryCollection(geometries.ToArray()).EnvelopeInternal;
				_minLon = _feature.MinX;
				_minLat = _feature.MinY;
				_maxLon = _feature.MaxX;
				_maxLat = _feature.MaxY;
				
				this._RafikiEnvironment = Mars.Components.Environments.GeoHashEnvironment<Rafiki>
					.BuildByBBox(_feature.MinX, _feature.MinY, _feature.MaxX, _feature.MaxY);
				this._TreeEnvironment = Mars.Components.Environments.GeoHashEnvironment<Tree>
					.BuildByBBox(_feature.MinX, _feature.MinY, _feature.MaxX, _feature.MaxY);
			} 
			else if (_lowerLeft != null && _upperRight != null) {
				this._RafikiEnvironment = Mars.Components.Environments.GeoHashEnvironment<Rafiki>.BuildByBBox(_lowerLeft.Longitude, _lowerLeft.Latitude, _upperRight.Longitude, _upperRight.Latitude);
				this._TreeEnvironment = Mars.Components.Environments.GeoHashEnvironment<Tree>.BuildByBBox(_lowerLeft.Longitude, _lowerLeft.Latitude, _upperRight.Longitude, _upperRight.Latitude);
			} else {
				throw new ArgumentException("No environment boundary was used for agent layer 'TestLayer'");
			}
			
			_RafikiAgents = Mars.Components.Services.AgentManager.SpawnAgents<Rafiki>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Rafiki)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this, this._Precipitation, this._Temperature, this._TreeRaster });
			_TreeAgents = Mars.Components.Services.AgentManager.SpawnAgents<Tree>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Tree)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this, this._Precipitation, this._Temperature, this._TreeRaster });
			
			return true;
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public SavannaTrees.Rafiki _SpawnRafiki(double xcor = 0, double ycor = 0, int freq = 1) {
			var id = System.Guid.NewGuid();
			var agent = new SavannaTrees.Rafiki(id, this, _Register, _Unregister,
			_RafikiEnvironment,
			_Precipitation, 
			_Temperature, 
			_TreeRaster
		, 	xcor, ycor, freq);
			_RafikiAgents.Add(id, agent);
			return agent;
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public SavannaTrees.Tree _SpawnTree(double xcor = 0, double ycor = 0, int freq = 1) {
			var id = System.Guid.NewGuid();
			var agent = new SavannaTrees.Tree(id, this, _Register, _Unregister,
			_TreeEnvironment,
			_Precipitation, 
			_Temperature, 
			_TreeRaster
		, 	default(bool), 
			default(string), 
			default(double), 
			default(string)
		, 	xcor, ycor, freq);
			_TreeAgents.Add(id, agent);
			return agent;
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void _KillRafiki(SavannaTrees.Rafiki target, int executionFrequency = 1)
		{
			target._isAlive = false;
			_RafikiEnvironment.Remove(target);
			_Unregister(this, target, target._executionFrequency);
			_RafikiAgents.Remove(target.ID);
		}
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public void _KillTree(SavannaTrees.Tree target, int executionFrequency = 1)
		{
			target._isAlive = false;
			_TreeEnvironment.Remove(target);
			_Unregister(this, target, target._executionFrequency);
			_TreeAgents.Remove(target.ID);
		}
	}
}
