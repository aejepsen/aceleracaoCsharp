﻿using System.Diagnostics;
// ok
namespace CharacterCounter;
public class CharacterCounter
{
        /// <summary>
        /// This function aims to perform the character count of a given text
        /// </summary>
        /// <param name="text"> A value of type string, the text to be calculated</param>
        /// <returns>The number of characters of the text passed</returns>
        /// <exception cref="NullReferenceException">If text is null throw exception </exception>
        public int Action(string text)
        {
            var watch = new Stopwatch();
            watch.Start();
            if (text == null || text == "")
            {
                throw new NullReferenceException("Valor de texto inválido");
            }
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Stop();
            return text.Length;
        }
}
