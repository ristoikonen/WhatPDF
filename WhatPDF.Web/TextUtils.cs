using System.Text;
using System.Security.Cryptography;


namespace WhatPDF.Web
{
    public static class TextUtils
    {
        //private string SimulatedPage =
        //    "Test Page" + Environment.NewLine +
        //    "Important Heading (ignored)" + Environment.NewLine +
        //    "The project overview starts here, detailing scope and objectives. This text is deep inside the document, perhaps in a div or p tag." + Environment.NewLine +
        //    "We need a unique identifier for this document, and we will base it on a random word found within this content block, making the source tag-agnostic." + Environment.NewLine +
        //    "Contact info: example@corp.com.";



        /// <summary>
        /// Selects a random word from that text block.
        /// </summary>
        /// <returns>A random word found in the page text to use as the ID source.</returns>
        public static string? GetRandomWordFromFullText(string fullText)
        {

            if (string.IsNullOrEmpty(fullText))
            {
                return null;
            }

            // 3. Split the entire text block into individual words, using multiple delimiters
            string[] words = fullText.Split(
                new[] { ' ', '.', ',', ':', ';', '(', ')', '\r', '\n', '\t', },
                StringSplitOptions.RemoveEmptyEntries
            );

            // 4. Select a random word
            if (words.Length > 0)
            {
                int index = Random.Shared.Next(words.Length);
                // Ensure the word is trimmed and potentially converted to lowercase for consistency
                return words[index].Trim().ToLowerInvariant();
            }

            return "default_content_key";
        }

        /// <summary>
        /// Converts a source string into a Base64 encoded string.
        /// </summary>
        /// <param name="source">The string data to encode.</param>
        /// <returns>The Base64 encoded string.</returns>
        public static string CreateBase64String(string source)
        {
            // Convert the string to a byte array using UTF-8 encoding
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);

            // Convert the byte array to a Base64 string.
            return Convert.ToBase64String(sourceBytes);
        }

        public static string CreateBase64String(string source, int len)
        {
            // Convert the string to a byte array using UTF-8 encoding
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);

            // Convert the byte array to a Base64 string.
            //TODO: Test!
            return (string)Convert.ToBase64String(sourceBytes).Take(len);
        }

        /// <summary>
        /// Decodes a Base64 string back into the original string.
        /// </summary>
        public static string DecodeBase64String(string base64String)
        {
            // Convert the Base64 string back to a byte array
            byte[] decodedBytes = Convert.FromBase64String(base64String);

            // Convert the byte array back to a string using UTF-8 encoding
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }

}





