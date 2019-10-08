using Microsoft.Extensions.ML;
using NetCoreReact.Models.ML;
using NetCoreReact.Services.ML.Interfaces;

namespace NetCoreReact.Services.ML
{
	public class PredictionService : IPredictionService
	{
		private readonly PredictionEnginePool<PredictionInput, PredictionOutput> _predictionEnginePool;

		public PredictionService(PredictionEnginePool<PredictionInput, PredictionOutput> predictionEnginePool)
		{
			_predictionEnginePool = predictionEnginePool;
		}

		public PredictionOutput Predict(PredictionInput input)
		{
			return _predictionEnginePool.Predict(modelName: "MLModel", example: input);
			//MLContext mlContext = new MLContext();

			// Load model & create prediction engine
			//string modelPath = AppDomain.CurrentDomain.BaseDirectory + "MLModel.zip";
			//ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
			//var predEngine = mlContext.Model.CreatePredictionEngine<PredictionInput, PredictionOutput>(mlModel);

			// Use model to make prediction on input data
			//PredictionOutput result = predEngine.Predict(input);
			//return result;
		}
	}
}
