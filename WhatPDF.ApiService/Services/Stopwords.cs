namespace WhatPDF.ApiService.Services;

public class StopWords
{
    public const string EnglishStopWords =
        "a,an,the,and,but,if,or,because,as,until,while,of,at,by,for,with,about,against,between,into," +
        "through,during,before,after,above,below,to,from,up,down,in,out,on,off,over,under,again,further," +
        "then,once,here,there,when,where,why,how,all,any,both,each,few,more,most,other,some,such,no,nor," +
        "not,only,own,same,so,too,very,s,t,can,will,just,don,should,now";

    public static HashSet<string> GetStopWordSet()
    {
        // Use an efficient HashSet for O(1) lookups
        return new HashSet<string>(
            EnglishStopWords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries),
            StringComparer.OrdinalIgnoreCase 
        );
    }
}