namespace bulls_and_cows___jonatan
{
      public class Program
    {
        public static void Main(string[] args)
        {
            // Step 1: Create one BullsAndCowsGame object. Its constructor already picks a secret number.
            var game = new BullsAndCowsGame();

            // Step 2: Create an empty list to hold GuessRecord objects (history for the current game).
            var history = new List<GuessRecord>();

            // Step 3: Print the welcome message and rules once.
            PrintWelcome();

            // Step 4: Repeat forever (the main loop).
            while (true)
            {
                // a. Print a prompt and read one line of text from the player.
                Console.Write("\nEnter your guess (or q/quit, n/new, h/history): ");
                string input = Console.ReadLine();

                // b. If the text is empty, skip back to the top of the loop and ask again.
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                input = input.Trim();

                // c. If the text matches 'quit' -> print a goodbye message and exit the loop.
                if (IsQuit(input))
                {
                    Console.WriteLine("Thanks for playing Bulls and Cows. Goodbye!");
                    break;
                }

                // d. Else if the text matches 'new game' -> call StartNewGame(), clear history, print message.
                if (IsNewGame(input))
                {
                    game.StartNewGame();
                    history.Clear();
                    Console.WriteLine("A new game has started. A fresh secret number has been picked!");
                    continue;
                }

                // e. Else if the text matches 'history' -> print every record in the history list.
                if (IsHistory(input))
                {
                    PrintHistory(history);
                    continue;
                }

                // f. Else if the game is already over -> tell the player to start a new game.
                if (game.IsGameOver)
                {
                    Console.WriteLine("The game is already over! Type 'n' to start a new game, or 'q' to quit.");
                    continue;
                }

                // g. Else, treat the text as a guess: first call IsValidGuess.
                if (!BullsAndCowsGame.IsValidGuess(input, out string errorMessage))
                {
                    Console.WriteLine($"Invalid guess: {errorMessage}");
                    continue;
                }

                // h. If the guess is valid, call SubmitGuess and get back a GuessResult.
                GuessResult result = game.SubmitGuess(input);

                // i. Build a new GuessRecord from the result and add it to the history list.
                var record = new GuessRecord
                {
                    AttemptNumber = game.AttemptCount,
                    Guess = input,
                    Bulls = result.Bulls,
                    Cows = result.Cows
                };
                history.Add(record);

                // j. Print the Bulls/Cows feedback.
                Console.WriteLine($"Result: {record.Feedback}");

                // k. If the result is a winning guess, print a victory message with total attempts.
                if (result.IsWinningGuess)
                {
                    Console.WriteLine(
                        $"\nCongratulations! You guessed the secret number in {game.AttemptCount} attempts!");
                    Console.WriteLine("Type 'n' to play again, or 'q' to quit.");
                }
            }
            // Step 5: (Loop repeats from step 4 until the player quits.)
        }

        /// <summary>
        /// Checks if the player's input matches the "quit" command, ignoring uppercase/lowercase.
        /// </summary>
        private static bool IsQuit(string input)
        {
            string text = input.ToLower();
            return text == "q" || text == "quit" || text == "exit";
        }

        /// <summary>
        /// Checks if the player's input matches the "new game" command, ignoring uppercase/lowercase.
        /// </summary>
        private static bool IsN
