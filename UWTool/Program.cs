using Brotli;
using UWTool;
using File = System.IO.File;

if (args.Length < 1)
{
    var helpMessage = new[]
    {
        "Usage:",
        "<input_path>: Input path of .unityweb compressed file. (REQUIRED)",
        "<output_path>: Output path to uncompressed file. (OPTIONAL)"
    };
    Console.WriteLine(string.Join("\n", helpMessage));
    return;
}


var inputFilePath = args[0];
var compressedData = File.ReadAllBytes(inputFilePath);
if (UnityWeb.HasUnityMarker(compressedData))
{
    string outputFilePath;
    if (args.Length < 2)
    {
        var directoryName = Path.GetDirectoryName(inputFilePath) ?? string.Empty;
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputFilePath).Trim();
        var extension = Path.GetExtension(inputFilePath);
        var outputFileName = "output_" + fileNameWithoutExtension + extension;
        outputFilePath = Path.Combine(directoryName, outputFileName);
    }
    else
    {
        outputFilePath = args[1];
    }
    var fileName = Path.GetFileName(inputFilePath).Trim();
    var uncompressedData = compressedData.DecompressFromBrotli();
    File.WriteAllBytes(outputFilePath, uncompressedData);
    Console.WriteLine($"{fileName} file has decompressed from Brotli.");
    Console.WriteLine($"Output path: {outputFilePath}.");
}
else
{
    Console.WriteLine("The file don't contains brotli header.");
}

