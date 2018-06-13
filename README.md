# ML.NET Serialization Example

This repo is a sample application that shows how to use the newly introduced CollectionDataSource feature to load in data from files or System Collections. This is based off the [MulticlassClassification_Iris](https://github.com/dotnet/machinelearning-samples/tree/master/samples/getting-started/MulticlassClassification_Iris) sample on GitHub.

## Requirements

This app was build on a Linux PC, but should work cross-platform on Mac and Windows

- [.NET Core 2.0](https://www.microsoft.com/net/download/linux)

## Build Project

```bash
dotnet restore
dotnet build
```

## Run Sample

```bash
dotnet run -p myconsoleapp/myconsoleapp.csproj
```

Sample Output:

```bash
Automatically adding a MinMax normalization transform, use 'norm=Warn' or 'norm=No' to turn this behavior off.
Using 2 threads to train.
Automatically choosing a check frequency of 2.
Auto-tuning parameters: maxIterations = 12498.
Auto-tuning parameters: L2 = 2.66752E-05.
Auto-tuning parameters: L1Threshold (L1/L2) = 0.
Using best model from iteration 6.
Not training a calibrator because it is not needed.

Actual: setosa.     Predicted probability: setosa:      0.3475
                                           versicolor:  0.3316
                                           virginica:   0.3209
```