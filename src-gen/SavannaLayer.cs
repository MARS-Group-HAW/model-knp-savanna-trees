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
	public class SavannaLayer : Mars.Components.Layers.AbstractLayer {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(SavannaLayer));
		private readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		public Mars.Interfaces.Layer.UnregisterAgent _Unregister { get; set; }
		public Mars.Interfaces.Layer.RegisterAgent _Register { get; set; }
		private double?[] _bbox = new double?[4]; private int? _cellSizeMeters;
		public Mars.Components.Environments.GeoGridHashEnvironment<Rafiki> _RafikiEnvironment { get; set; }
		public Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment { get; set; }
		public Precipitation _Precipitation { get; set; }
		public Temperature _Temperature { get; set; }
		public TreeRaster _TreeRaster { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Rafiki> _RafikiAgents { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Tree> _TreeAgents { get; set; }
		public SavannaLayer _SavannaLayer => this;
		public SavannaLayer (
		Precipitation _precipitation, Temperature _temperature, TreeRaster _treeraster, 
		double? topLatitude = null, double? bottomLatitude = null, double? leftLatitude = null, double? rightLatitude = null, int? cellSizeMeters = null) {
			this._Precipitation = _precipitation;
			this._Temperature = _temperature;
			this._TreeRaster = _treeraster;
			_bbox[0] = topLatitude;_bbox[1] = bottomLatitude;_bbox[2] = leftLatitude;_bbox[3] = rightLatitude;
			_cellSizeMeters = cellSizeMeters;
		}
		
		public override bool InitLayer(
			Mars.Interfaces.Layer.Initialization.TInitData initData, 
			Mars.Interfaces.Layer.RegisterAgent regHandle, 
			Mars.Interfaces.Layer.UnregisterAgent unregHandle)
		{
			if (_bbox.All(d => d.HasValue) && _cellSizeMeters.HasValue) {
				this._RafikiEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Rafiki>.BuildEnvironment(_bbox[0].Value, _bbox[1].Value, _bbox[2].Value, _bbox[3].Value, _cellSizeMeters.Value);
				this._TreeEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Tree>.BuildEnvironment(_bbox[0].Value, _bbox[1].Value, _bbox[2].Value, _bbox[3].Value, _cellSizeMeters.Value);
			} else
			{
				var geometries = new List<GeoAPI.Geometries.IGeometry>();
				var _factory = new NetTopologySuite.Utilities.GeometricShapeFactory();
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._Precipitation.Metadata.LowerLeftBound.Longitude, this._Precipitation.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._Precipitation.Metadata.CellSizeInDegree * this._Precipitation.Metadata.HeightInGridCells;
				_factory.Width = this._Precipitation.Metadata.CellSizeInDegree * this._Precipitation.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._Temperature.Metadata.LowerLeftBound.Longitude, this._Temperature.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._Temperature.Metadata.CellSizeInDegree * this._Temperature.Metadata.HeightInGridCells;
				_factory.Width = this._Temperature.Metadata.CellSizeInDegree * this._Temperature.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._TreeRaster.Metadata.LowerLeftBound.Longitude, this._TreeRaster.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._TreeRaster.Metadata.CellSizeInDegree * this._TreeRaster.Metadata.HeightInGridCells;
				_factory.Width = this._TreeRaster.Metadata.CellSizeInDegree * this._TreeRaster.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				var _feature = new NetTopologySuite.Geometries.GeometryCollection(geometries.ToArray()).Envelope;
				this._RafikiEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Rafiki>.BuildEnvironment(_feature.Coordinates[1].Y, _feature.Coordinates[0].Y, _feature.Coordinates[0].X, _feature.Coordinates[2].X, _cellSizeMeters ?? 100);
				this._TreeEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Tree>.BuildEnvironment(_feature.Coordinates[1].Y, _feature.Coordinates[0].Y, _feature.Coordinates[0].X, _feature.Coordinates[2].X, _cellSizeMeters ?? 100);
			}
			
			_RafikiAgents = Mars.Components.Services.AgentManager.SpawnAgents<Rafiki>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Rafiki)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this, this._Precipitation, this._Temperature, this._TreeRaster });
			_TreeAgents = Mars.Components.Services.AgentManager.SpawnAgents<Tree>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Tree)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this, this._Precipitation, this._Temperature, this._TreeRaster });
			
			this._Register = regHandle;
			this._Unregister = unregHandle;
			return base.InitLayer(initData, regHandle, unregHandle);
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
