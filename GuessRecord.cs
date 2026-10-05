using System;

namespace bulls_and_cows___jonatan;
public class GuessRecord
    {
        public int AttemptNumber { get; set; }
        public string Guess { get; set; }
        public int Bulls { get; set; }
        public int Cows { get; set; }

        /// <summary>
        /// A friendly combined string such as "1 Bulls, 2 Cows", built from Bulls and Cows.
        /// </summary>
        public string Feedback => $"{Bulls} Bulls, {Cows} Cows";
    }