namespace WhatPDF.ApiService.Services;

public interface IQuickLZ
{
    public byte[] Compress(byte[] source, int level);
    public byte[] Decompress(byte[] source);
}
