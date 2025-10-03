namespace WhatPDF.ApiService.Services;

public interface IQuickLZ
{
    public byte[] Compress(byte[] source, int level);
    public byte[] Decompress(byte[] source);
}

public interface IStopwords
{
    public string Remove(string text);
}

public class Stopwords : IStopwords
{
    public string Remove(string text)
    {
        string filePath = @".\Resources\stopwords.txt";
        string stopwords = File.ReadAllText(filePath);
        //string stopwords = File.ReadAllText(@".\.\resources\stopwords.txt");

        if (!string.IsNullOrWhiteSpace(text))
        {
            var words = text.ToLowerInvariant().Split(' ');
            return string.Join(" ", words.Where(word => !stopwords.Contains(word)));
        }
        return "";
    }
}

