using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace myconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = TrainAsync().Result;

            var prediction = model.Predict(new IrisData(){
                SepalLength = 3.3f,
                SepalWidth = 1.6f,
                PetalLength = 0.2f,
                PetalWidth= 5.1f
            });

            Console.WriteLine(prediction.Score[0]);
            Console.WriteLine(prediction.Score[1]);
            Console.WriteLine(prediction.Score[2]);
        }

        static async Task<PredictionModel<IrisData,IrisPrediction>> TrainAsync()
        {
            LearningPipeline pipeline = new LearningPipeline();
            
            var collection = CollectionDataSource.Create(await getData(@"./myconsoleapp/traindata.json"));

            pipeline.Add(collection);

            pipeline.Add(new ColumnConcatenator("Features","SepalLength","SepalWidth","PetalLength","PetalWidth"));
                
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            var model = pipeline.Train<IrisData,IrisPrediction>();

            return model;
        }

        static async Task<List<IrisData>> getData(string path)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IrisDataList));

            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(await File.OpenText(path).ReadToEndAsync()));

            IrisDataList training_data = (IrisDataList)ser.ReadObject(ms);

            return training_data.Data;
        }


    }
}
